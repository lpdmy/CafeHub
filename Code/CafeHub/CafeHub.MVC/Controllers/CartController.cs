using CafeHub.Commons.Models;
using CafeHub.MVC.Models;
using CafeHub.Services.Interfaces;
using CafeHub.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CafeHub.MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IAccountService _accountService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public CartController(ICartService cartService, IAccountService accountService, ICategoryService categoryService, IProductService productService)
        {
            _cartService = cartService;
            _accountService = accountService;
            _categoryService = categoryService;
            _productService = productService;
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

            // Retrieve the product to get the base price
            var product = await _productService.GetProductByIdAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            // Calculate the updated price based on size
            decimal finalPrice = product.Price;
            switch (size)
            {
                case "Medium":
                    finalPrice *= 1.3m; // +30%
                    break;
                case "Large":
                    finalPrice *= 1.5m; // +50%
                    break;
            }

            var cartItems = await _cartService.GetCartItemsByUserIdAsync(userId);
            var existingItem = cartItems.FirstOrDefault(x =>
                x.ProductId == productId &&
                x.Size == size &&
                x.SugarAmount == sugarAmount &&
                x.IceAmount == iceAmount);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                existingItem.UnitPrice = finalPrice; // Update price in case it changes
                await _cartService.UpdateCartItemAsync(userId, existingItem, existingItem.Size, existingItem.SugarAmount, existingItem.IceAmount);
            }
            else
            {
                var orderItem = new OrderItem
                {
                    ProductId = productId,
                    Quantity = quantity,
                    Size = size,
                    SugarAmount = sugarAmount,
                    IceAmount = iceAmount,
                    UnitPrice = finalPrice // Store the calculated price
                };

                await _cartService.AddToCartAsync(userId, orderItem);
            }

            return RedirectToAction("Index");
        }



        [HttpPost]
        public async Task<IActionResult> UpdateCart(List<OrderItemViewModel> CartItems)
        {
            var userId = await _accountService.GetCurrentUserIdAsync();

            if (CartItems == null || !CartItems.Any())
            {
                Debug.WriteLine("DEBUG: CartItems is null or empty");
                TempData["ErrorMessage"] = "Your cart is empty!";
                return RedirectToAction("Index");
            }

            foreach (var item in CartItems)
            {
                if (item.Quantity <= 0)
                {
                    Debug.WriteLine($"DEBUG: Invalid quantity for ProductId {item.ProductId}");
                    continue; // Or remove the item
                }

                var updatedItem = new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Size = item.Size,
                    SugarAmount = item.SugarAmount,
                    IceAmount = item.IceAmount
                };

                await _cartService.UpdateCartItemAsync(userId, updatedItem,
                item.OriginalSize, item.OriginalSugarAmount, item.OriginalIceAmount);

            }

            TempData["SuccessMessage"] = "Cart updated successfully!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int productId, string size, int sugarAmount, int iceAmount)
        {
            var userId = await _accountService.GetCurrentUserIdAsync();

            await _cartService.RemoveCartItemAsync(userId, productId, size, sugarAmount, iceAmount);

            TempData["SuccessMessage"] = "Item removed from cart!";
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
