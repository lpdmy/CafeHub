using System.ComponentModel.DataAnnotations;

namespace CafeHub.MVC.Models
{
    public class CreateProductViewModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;

        [Required]
        public int CategoryId { get; set; }

        public bool IsAvailable { get; set; } = true;

        public IFormFile? Image { get; set; } // New property for image upload
    }

}
