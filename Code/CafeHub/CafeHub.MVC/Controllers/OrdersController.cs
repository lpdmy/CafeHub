using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CafeHub.Commons;
using CafeHub.Commons.Models;
using CafeHub.Services.Interfaces;
using CafeHub.Services.Services;
using CafeHub.MVC.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using CafeHub.Services.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using CafeHub.Service.Interfaces;

namespace CafeHub.MVC.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IAccountService _accountService;
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly IPaymentService _paymentService;
        private readonly IProductService _productService;
        private readonly IVnPayService _vnPayService;
        private readonly IDiscountService _discountService;
        public OrdersController(ApplicationDbContext context, IAccountService accountService, ICartService cartService, IOrderService orderService, 
           IPaymentService paymentService, IProductService productService, IVnPayService vnPayService, IDiscountService discountService )
        {
            _context = context;
            _accountService = accountService;
            _cartService = cartService;
            _orderService = orderService;
            _paymentService = paymentService;
            _productService = productService;
            _vnPayService = vnPayService;
            _discountService = discountService;
        }


        // GET: Orders/Create (Checkout Page)
        public async Task<IActionResult> Create()
        {
            var customer = await _accountService.GetCurrentCustomerAsync();

            if (customer == null)
            {
                TempData["Error"] = "You are not a customer!";
                return RedirectToAction("Index", "Cart");
            }

            var cartItems = await _cartService.GetCartItemsByUserIdAsync(customer.Id);

            if (cartItems == null || !cartItems.Any())
            {
                TempData["Error"] = "Your cart is empty!";
                return RedirectToAction("Index", "Cart");
            }

            // Get applicable discounts for the customer
            var availableDiscounts = await _discountService.GetDiscountsByMembershipTypeAsync(customer.MembershipType);

            var model = new OrderViewModel
            {
                CustomerName = customer.FullName,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address,
                TotalAmount = cartItems.Sum(x => x.Quantity * GetFinalPrice(x.Product.Price, x.Size)), // Adjusted here
                OrderItems = cartItems.Select(x => new OrderItemViewModel
                {
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    Quantity = x.Quantity,
                    Size = x.Size,
                    SugarAmount = x.SugarAmount,
                    IceAmount = x.IceAmount,
                    UnitPrice = GetFinalPrice(x.Product.Price, x.Size) // Ensure correct price per item
                }).ToList(),
                AvailableDiscounts = availableDiscounts.Select(d => new DiscountViewModel
                {
                    Id = d.Id,
                    Name = d.DiscountName,
                    DiscountValue = d.DiscountValue,
                    DiscountType = d.DiscountType,
                    ImageUrl = d.ImageUrl
                }).ToList()
            };

            return View(model);
        }


        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderViewModel model)
        {
            var userId = await _accountService.GetCurrentUserIdAsync();
            var user = await _accountService.GetUserByIdAsync(userId);

            if (!ModelState.IsValid)
            {
                foreach (var item in model.OrderItems.Where(x => x != null))
                {
                    var product = await _productService.GetProductByIdAsync(item.ProductId);
                    if (product != null)
                    {
                        item.ProductName = product.Name;
                        item.UnitPrice = GetFinalPrice(product.Price, item.Size); // Updated to ensure price adjustment
                    }
                }
                return View(model);
            }

            var cartItems = await _cartService.GetCartItemsByUserIdAsync(userId);
            decimal totalAmount = cartItems.Sum(x => x.Quantity * GetFinalPrice(x.Product.Price, x.Size)); // Adjusted here
                                                                                                           // Apply selected discount if valid
            if (model.SelectedDiscountId.HasValue)
            {
                var discount = await _context.Discounts.FindAsync(model.SelectedDiscountId.Value);
                if (discount != null && discount.IsActive && discount.StartDate <= DateTime.Now && discount.EndDate >= DateTime.Now)
                {
                    if (discount.DiscountType == "Percentage")
                    {
                        totalAmount -= (totalAmount * (decimal)discount.DiscountValue / 100);
                    }
                    else if (discount.DiscountType == "FixedAmount")
                    {
                        totalAmount -= (decimal)discount.DiscountValue;
                    }

                    // Ensure totalAmount doesn't go below zero
                    totalAmount = Math.Max(totalAmount, 0);

                    // Save discount to CustomerDiscount table
                    await _discountService.ApplyDiscountForCustomerAsync(userId, discount.Id);
                }
            }
            var order = new Order
            {
                CustomerId = userId,
                OrderDate = DateTime.Now,
                TotalAmount = totalAmount,
                Status = "Pending",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMinutes(5),
                OrderItems = model.OrderItems
                    .Where(x => x != null)
                    .Select(x => new OrderItem
                    {
                        ProductId = x.ProductId,
                        Quantity = x.Quantity,
                        Size = x.Size,
                        SugarAmount = x.SugarAmount,
                        IceAmount = x.IceAmount,
                        UnitPrice = GetFinalPrice(x.UnitPrice, x.Size) // Ensure correct price is stored
                    }).ToList()
            };

            await _orderService.CreateOrderAsync(order);

            // Optional: Clear cart
            await _cartService.ClearCartByUserIdAsync(userId);

            if (model.PaymentMethod == "VNPAY")
            {
                return Redirect(await _vnPayService.GetPaymentUrl(order.Id));
            }

            await _paymentService.CreatePaymentAsync(new Payment
            {
                OrderId = order.Id,
                AmountPaid = order.TotalAmount,
                PaymentMethod = "Cash",
                PaymentDate = DateTime.UtcNow
            });
            return RedirectToAction(nameof(Details), new { id = order.Id });
        }



        public async Task<IActionResult> VnPayReturn()
        {
            var resultMessage = await _vnPayService.ProcessPaymentResponse(HttpContext.Request.Query);
            ViewBag.Message = resultMessage; // Set message directly
            return View("PaymentResult"); 
        }

        public async Task<IActionResult> Details(int id)
        {
            var customer = await _accountService.GetCurrentCustomerAsync();

            if (customer == null)
            {
                TempData["Error"] = "You are not a customer!";
                return RedirectToAction("Index", "Cart");
            }
            var order = await _orderService.GetOrderDetailsAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            var payment = await _paymentService.GetPaymentByOrderIdAsync(order.Id); // Get payment details
            var customerDiscount = await _discountService.GetDiscountByCustomerIdAsync(customer.Id); // Get customer discount

            var viewModel = new OrderViewModel
            {
                Id = order.Id,
                CustomerName = customer.FullName,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address,
                TotalAmount = order.TotalAmount,
                PaymentMethod = payment?.PaymentMethod ?? "N/A", // Assign PaymentMethod from Payment table
                SelectedDiscountId = customerDiscount?.DiscountId, // Assign discount ID from CustomerDiscount
                AvailableDiscounts = customerDiscount != null
                    ? new List<DiscountViewModel>
                    {
                new DiscountViewModel
                {
                    Id = customerDiscount.Discount.Id,
                    Name = customerDiscount.Discount.DiscountName,
                    DiscountType = customerDiscount.Discount.DiscountType,
                    DiscountValue = customerDiscount.Discount.DiscountValue
                }
                    }
                    : new List<DiscountViewModel>(),
                OrderItems = order.OrderItems.Select(oi => new OrderItemViewModel
                {
                    ProductName = oi.Product.Name,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice
                }).ToList()
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> RecalculateTotal(int discountId)
        {
            var userId = await _accountService.GetCurrentUserIdAsync();
            var cartItems = await _cartService.GetCartItemsByUserIdAsync(userId);

            if (cartItems == null || !cartItems.Any())
            {
                return Json(new { totalAmount = 0 });
            }

            decimal totalAmount = cartItems.Sum(x => x.Quantity * GetFinalPrice(x.Product.Price, x.Size));

            // Apply selected discount
            var discount = await _context.Discounts.FindAsync(discountId);
            if (discount != null && discount.IsActive && discount.StartDate <= DateTime.Now && discount.EndDate >= DateTime.Now)
            {
                if (discount.DiscountType == "Percentage")
                {
                    totalAmount -= (totalAmount * (decimal)discount.DiscountValue / 100);
                }
                else if (discount.DiscountType == "FixedAmount")
                {
                    totalAmount -= (decimal)discount.DiscountValue;
                }

                totalAmount = Math.Max(totalAmount, 0); // Prevent negative values
            }

            return Json(new { totalAmount });
        }


        private decimal GetFinalPrice(decimal basePrice, string size)
        {
            switch (size)
            {
                case "Medium":
                    return basePrice * 1.3m; // +30%
                case "Large":
                    return basePrice * 1.5m; // +50%
                default:
                    return basePrice; // Small (default)
            }
        }


    }

}

