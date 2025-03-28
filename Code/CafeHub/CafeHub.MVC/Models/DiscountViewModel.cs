using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http; // Required for IFormFile

namespace CafeHub.MVC.Models
{
    public class DiscountViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string DiscountType { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Discount percentage must be between 0 and 100.")]
        public float DiscountValue { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public string Condition { get; set; }

        public string? ImageUrl { get; set; } // Store the file path of the uploaded image

        [Display(Name = "Upload Image")]
        public IFormFile? ImageFile { get; set; } // Used for file uploads
    }
}
