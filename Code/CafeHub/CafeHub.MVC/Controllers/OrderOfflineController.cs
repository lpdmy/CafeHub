using CafeHub.Commons.Models;
using CafeHub.MVC.Models;
using CafeHub.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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
    }
}