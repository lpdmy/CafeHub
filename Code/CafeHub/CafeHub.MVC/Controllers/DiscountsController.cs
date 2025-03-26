using CafeHub.Commons.Models;
using CafeHub.Service.Interfaces;
using CafeHub.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeHub.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DiscountsController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public DiscountsController(IDiscountService discountService, IWebHostEnvironment webHostEnvironment)
        {
            _discountService = discountService;
            _webHostEnvironment = webHostEnvironment;
        }

        // Display all discounts
        public async Task<IActionResult> Index()
        {
            var discounts = await _discountService.GetAllDiscountsAsync();
            var model = discounts.Select(d => new DiscountViewModel
            {
                Id = d.Id,
                Name = d.DiscountName,
                DiscountType = d.DiscountType,
                DiscountValue = d.DiscountValue,
                IsActive = d.IsActive,
                StartDate = d.StartDate,
                EndDate = d.EndDate,
                Condition = d.Condition,
                ImageUrl = d.ImageUrl
            }).ToList();

            return View(model);
        }

        // Show discount creation form
        public IActionResult Create()
        {
            return View();
        }

        // Handle discount creation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DiscountViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            string? imageUrl = null;

            if (model.ImageFile != null)
            {
                // Get the images folder path
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");

                // Ensure the folder exists
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Use the original file name (prevent duplicates by checking existence)
                string fileName = model.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, fileName);


                // Save the file with the final filename
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(fileStream);
                }

                // Store the relative path for use in HTML
                imageUrl = "/images/" + fileName;
            }

            var discount = new Discount
            {
                DiscountName = model.Name,
                DiscountType = model.DiscountType,
                DiscountValue = model.DiscountValue,
                IsActive = model.IsActive,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Condition = model.Condition,
                ImageUrl = imageUrl // Store the image URL in the database
            };

            await _discountService.AddDiscountAsync(discount);
            return RedirectToAction(nameof(Index));
        }



        // Show edit form
        public async Task<IActionResult> Edit(int id)
        {
            var discount = await _discountService.GetDiscountByIdAsync(id);
            if (discount == null) return NotFound();

            var model = new DiscountViewModel
            {
                Id = discount.Id,
                Name = discount.DiscountName,
                DiscountType = discount.DiscountType,
                DiscountValue = discount.DiscountValue,
                IsActive = discount.IsActive,
                StartDate = discount.StartDate,
                EndDate = discount.EndDate,
                Condition = discount.Condition,
                ImageUrl = discount.ImageUrl
            };

            return View(model);
        }

        // Handle discount updates
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Edit(int id, DiscountViewModel model)
        {
            if (id != model.Id) return NotFound();
            if (!ModelState.IsValid) return View(model);

            // Fetch the existing discount (tracked by EF)
            var existingDiscount = await _discountService.GetDiscountByIdAsync(id);
            if (existingDiscount == null) return NotFound();

            // Preserve the old image URL if no new file is uploaded
            if (model.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string fileName = model.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(fileStream);
                }

                existingDiscount.ImageUrl = "/images/" + fileName; // Update image if new file uploaded
            }

            // Update existing discount fields
            existingDiscount.DiscountName = model.Name;
            existingDiscount.DiscountType = model.DiscountType;
            existingDiscount.DiscountValue = model.DiscountValue;
            existingDiscount.IsActive = model.IsActive;
            existingDiscount.StartDate = model.StartDate;
            existingDiscount.EndDate = model.EndDate;
            existingDiscount.Condition = model.Condition;

            // Save changes (EF is already tracking the entity)
            await _discountService.UpdateDiscountAsync(existingDiscount);
            return RedirectToAction(nameof(Index));
        }

        // Show delete confirmation
        public async Task<IActionResult> Delete(int id)
        {
            var discount = await _discountService.GetDiscountByIdAsync(id);
            if (discount == null) return NotFound();

            var model = new DiscountViewModel
            {
                Id = discount.Id,
                Name = discount.DiscountName,
                DiscountType = discount.DiscountType,
                DiscountValue = discount.DiscountValue,
                IsActive = discount.IsActive,
                StartDate = discount.StartDate,
                EndDate = discount.EndDate,
                Condition = discount.Condition,
                ImageUrl = discount.ImageUrl
            };

            return View(model);
        }

        // Handle discount deletion
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _discountService.RemoveDiscountAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
