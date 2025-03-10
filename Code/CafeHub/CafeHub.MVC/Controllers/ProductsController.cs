using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CafeHub.Commons.Models;
using CafeHub.Services.Interfaces;
using CafeHub.MVC.Models;

namespace CafeHub.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        // GET: Products
        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();
            var categories = _categoryService.GetAllCategories();

            // Truyền danh sách Category vào ViewBag
            ViewBag.Categories = categories;

            return View(products);
        }


        // GET: Products/Details/5
        public IActionResult Details(int id)
        {
            var product = _productService.GetProductById(id);
            var categories = _categoryService.GetAllCategories();
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.Categories = categories;
            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAllCategories(), "Id", "Name");
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                Product pro = new Product()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    CategoryId = model.CategoryId
                };
                _productService.CreateProduct(pro);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAllCategories(), "Id", "Name", model.CategoryId);
            return View(model);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAllCategories(), "Id", "Name", product.CategoryId);
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditProductViewModel model)
        {
            

            if (ModelState.IsValid)
            {
                Product pro = new Product()
                {
                    
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    CategoryId = model.CategoryId
                };
                _productService.UpdateProduct(pro);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAllCategories(), "Id", "Name", model.CategoryId);
            return View(model);
        }


        // GET: Products/Delete/5
        public IActionResult Delete(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _productService.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
