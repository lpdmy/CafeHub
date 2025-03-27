using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace CafeHub.MVC.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Description can't exceed 500 characters.")]
        public string Description { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public string? ExistingImagePath { get; set; } // To store existing image (for Edit)

        [Display(Name = "Category Image")]
        public IFormFile? Image { get; set; } // Image Upload Property
    }
}
