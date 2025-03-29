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

namespace CafeHub.MVC.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IAccountService _accountService;
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        public OrdersController(ApplicationDbContext context, IAccountService accountService, ICartService cartService, IOrderService orderService)
        {
            _context = context;
            _accountService = accountService;
            _cartService = cartService;
            _orderService = orderService;
        }
        // GET: Order/Create (Checkout Page)
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

            var model = new OrderViewModel
            {
                CustomerName = customer.FullName,
                PhoneNumber = customer.PhoneNumber,
                Address = customer.Address,
                TotalAmount = cartItems.Sum(x => x.Quantity * x.Product.Price), // Adjust if size affects price
                OrderItems = cartItems.Select(x => new OrderItemViewModel
                {
                    ProductId = x.ProductId,
                    ProductName = x.Product.Name,
                    Quantity = x.Quantity,
                    Size = x.Size,
                    SugarAmount = x.SugarAmount,
                    IceAmount = x.IceAmount
                }).ToList()
            };

            return View(model);
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderViewModel model)
        {
            var userId = await _accountService.GetCurrentUserIdAsync();
            var user = await _accountService.GetUserByIdAsync(userId);

            if (!ModelState.IsValid)
                return View(model);

            var order = new Order
            {
                CustomerId = userId,
                OrderDate = DateTime.Now,
                TotalAmount = model.TotalAmount,
                Status = "Pending",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMinutes(5), // Optional
                OrderItems = model.OrderItems.Select(x => new OrderItem
                {
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    Size = x.Size,
                    SugarAmount = x.SugarAmount,
                    IceAmount = x.IceAmount
                }).ToList()
            };

            await _orderService.CreateOrderAsync(order);

            // Optional: Clear cart
            await _cartService.ClearCartByUserIdAsync(userId);

            return RedirectToAction(nameof(Details), new { id = order.Id });
        }
    }

}

