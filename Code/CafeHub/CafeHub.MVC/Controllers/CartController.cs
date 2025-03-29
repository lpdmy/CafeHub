using CafeHub.Commons.Models;
using CafeHub.MVC.Models;
using CafeHub.Services.Interfaces;
using CafeHub.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace CafeHub.MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IAccountService _accountService;
        private readonly ICategoryService _categoryService;

        public CartController(ICartService cartService, IAccountService accountService, ICategoryService categoryService)
        {
            _cartService = cartService;
            _accountService = accountService;
            _categoryService = categoryService;
        }

        // GET: /Cart
        public async Task<IActionResult> Index()
        {
            var userId = await _accountService.GetCurrentUserIdAsync();
            var cartItems = await _cartService.GetCartItemsByUserIdAsync(userId);

            var model = cartItems.Select(x => new OrderItemViewModel
            {
                ProductId = x.ProductId,
                ProductName = x.Product.Name,
                UnitPrice = x.Product.Price,
                Quantity = x.Quantity,
                Size = x.Size,
                SugarAmount = x.SugarAmount,
                IceAmount = x.IceAmount
            }).ToList();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _categoryService.GetCategoriesWithProductsAsync(); 
            return View("AddToCart", categories);
        }



        // POST: /Cart/Add
        [HttpPost]
        public async Task<IActionResult> Add(int productId, int quantity, string size, int sugarAmount, int iceAmount)
        {
            var userId = await _accountService.GetCurrentUserIdAsync();

            var orderItem = new OrderItem
            {
                ProductId = productId,
                Quantity = quantity,
                Size = size,
                SugarAmount = sugarAmount,
                IceAmount = iceAmount,
                
            };

            await _cartService.AddToCartAsync(userId, orderItem);

            return RedirectToAction("Index");
        }

        // POST: /Cart/Clear
        [HttpPost]
        public async Task<IActionResult> Clear()
        {
            var userId = await _accountService.GetCurrentUserIdAsync();
            await _cartService.ClearCartByUserIdAsync(userId);
            return RedirectToAction("Index");
        }
    }

}
