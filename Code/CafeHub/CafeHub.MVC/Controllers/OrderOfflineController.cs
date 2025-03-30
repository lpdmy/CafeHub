using Aspose.Pdf;
using Aspose.Pdf.Text;
using CafeHub.Commons.Models;
using CafeHub.MVC.Models;
using CafeHub.Services.Interfaces;
using DinkToPdf;
using jsreport.Local;
using jsreport.Types;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace CafeHub.MVC.Controllers
{
    public class OrderOfflineController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public OrderOfflineController(IProductService productService, IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }

        // GET: OrderOffline/Index
        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return View(orders);
        }

        // GET: OrderOffline/Create
        public async Task<IActionResult> Create()
        {
            var products = await _productService.GetAllProductsAsync();
            var viewModel = new OrderOfflineViewModel
            {
                OrderItems = products.Select(p => new OrderItemViewModel
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                    UnitPrice = p.Price,
                    Quantity = 0
                }).ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderOfflineViewModel model)
        {
            string staffId = null;
            if (ModelState.IsValid)
            {
                decimal totalAmount = model.OrderItems.Sum(item => item.Quantity * item.UnitPrice);

                var order = new Order
                {
                    StaffId = staffId,
                    OrderDate = DateTime.UtcNow,
                    TotalAmount = totalAmount,
                    Status = "Pending",
                    StartDate = DateTime.UtcNow,
                    EndDate = null,
                    CustomerId = null,
                    OrderItems = model.OrderItems.Where(item => item.Quantity > 0).Select(item => new OrderItem
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice
                    }).ToList()
                };

                await _orderService.CreateOrderAsync(order);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> ChangeStatus(int id, string status)
        {
            var order = await _orderService.GetOrderDetailsAsync(id);
            if (order != null)
            {
                order.Status = status;
                await _orderService.UpdateOrderAsync(order);
            }

            var orders = await _orderService.GetAllOrdersAsync();

            return View("Index", orders);
        }
        public async Task<IActionResult> PrintBill(int id)
        {
            var order = await _orderService.GetOrderDetailsAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            var productIds = order.OrderItems.Select(item => item.ProductId).ToList();
            var products = await _productService.GetProductsByIds(productIds);

            var htmlContent = $@"
<html>
    <head>
        <style>
            body {{
                font-family: Arial, sans-serif;
                margin: 0;
                padding: 10px;
                text-align: center;
            }}
            h1 {{
                font-size: 28px;
                margin-bottom: 20px;
            }}
            table {{
                width: 100%;
                border-collapse: collapse;
                margin-top: 20px;
            }}
            th, td {{
                padding: 8px 15px;
                text-align: left;
                border: 1px solid #ccc;
            }}
            th {{
                background-color: #f2f2f2;
                font-weight: bold;
            }}
            .total {{
                font-size: 22px;
                font-weight: bold;
                margin-top: 20px;
            }}
            .footer {{
                margin-top: 20px;
                font-size: 16px;
            }}
        </style>
    </head>
    <body>
        <h1>Roast Cafe</h1>
        <p>SE17D09, FPT University, Da Nang</p>
        <h2>Hóa đơn cho đơn hàng {order.Id}</h2>
        <table>
            <tr>
                <th>Product</th>
                <th>Quantity</th>
                <th>Price</th>
                <th>Total</th>
            </tr>";

            foreach (var item in order.OrderItems)
            {
                var product = products.FirstOrDefault(p => p.Id == item.ProductId);
                string productName = product != null ? product.Name : "Unknown Product";

                htmlContent += $@"
        <tr>
            <td>{productName}</td>
            <td>{item.Quantity}</td>
            <td>{item.UnitPrice}</td>
            <td>{item.Quantity * item.UnitPrice}</td>
        </tr>";
            }

            htmlContent += $@"
        </table>
        <div class='total'>
            Total: {order.TotalAmount}
        </div>
        <div class='footer'>
            See you again!<br />
            WiFi: Project_PRN222<br />
            Password: Passmon
        </div>
    </body>
</html>";

            // Tạo PDF từ HTML bằng HtmlFragment
            var doc = new Document();
            var page = doc.Pages.Add();

            // Đặt kích thước giấy A6
            page.PageInfo.Width = 420; // A6 width in points
            page.PageInfo.Height = 620; // A6 height in points

            // Sử dụng HtmlFragment để thêm nội dung HTML vào PDF
            HtmlFragment htmlFragment = new HtmlFragment(htmlContent);
            page.Paragraphs.Add(htmlFragment);

            // Lưu file PDF vào stream
            var stream = new MemoryStream();
            doc.Save(stream);
            stream.Position = 0;

            return File(stream, "application/pdf", $"Bill_{order.Id}.pdf");
        }

    }
}