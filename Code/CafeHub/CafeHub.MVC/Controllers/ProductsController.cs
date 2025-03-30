using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CafeHub.Commons.Models;
using CafeHub.Services.Interfaces;
using CafeHub.MVC.Models;
using Microsoft.AspNetCore.Hosting;
using System.Drawing.Printing;

namespace CafeHub.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductsController(IProductService productService, ICategoryService categoryService, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Products
        public async Task<IActionResult> Index(string search, int page = 1, int pageSize = 5)
        {
            var products = await _productService.GetAllProductsAsync();
            var categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.Categories = categories;

            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                                                p.Description.Contains(search, StringComparison.OrdinalIgnoreCase))
                                   .ToList();
            }

            int totalUsers = products.Count();
            var pagedUsers = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.TotalPages = (int)Math.Ceiling((double)totalUsers / pageSize);
            ViewBag.CurrentPage = page;

            return View(pagedUsers);
        }




        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProductByIdAsync(id); 
            var categories = await _categoryService.GetAllCategoriesAsync();  

            if (product == null)
            {
                return NotFound();  
            }

            ViewBag.Categories = categories;
            return View(product);  
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();  
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name");  
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {

                // xử lí ảnh 

                string filePath = null;

                if (model.Image != null)
                {
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    Directory.CreateDirectory(uploadsFolder); // Ensure directory exists

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Image.CopyToAsync(fileStream);
                    }
                }

                var product = new Product
                {
                    Name = model.Name,
                    Price = model.Price,
                    Description = model.Description,
                    CategoryId = model.CategoryId,
                    IsAvailable = model.IsAvailable,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ImagePath = "/uploads/" + Path.GetFileName(filePath)
                };

                await _productService.CreateProductAsync(product); 
                return RedirectToAction(nameof(Index));  
            }

            var categories = await _categoryService.GetAllCategoriesAsync();
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name", model.CategoryId); 
            return View(model);  
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetProductByIdAsync(id); 
            if (product == null)
            {
                return NotFound();  
            }

            var categories = await _categoryService.GetAllCategoriesAsync(); 
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name", product.CategoryId);  
            return View(product);  
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product()
                {
                    Id = id,
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    CategoryId = model.CategoryId
                };

                await _productService.UpdateProductAsync(product); 
                return RedirectToAction(nameof(Index));  
            }

            var categories = await _categoryService.GetAllCategoriesAsync();
            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name", model.CategoryId); 
            return View(model);  
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);  
            if (product == null)
            {
                return NotFound();  
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.DeleteProductAsync(id);  
            return RedirectToAction(nameof(Index));  
        }
    }
}
