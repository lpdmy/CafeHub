using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Commons.Models
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string DiscountName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string DiscountType { get; set; } = string.Empty; // Percentage, FixedAmount, etc.

        [Required]
        [Range(0, 100, ErrorMessage = "Discount value must be between 0 and 100.")]
        public float DiscountValue { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        // New Column: Specifies conditions like customer rank eligibility (Gold, Platinum, etc.)
        [StringLength(50)]
        public string Condition { get; set; } = string.Empty;

        // New field to store the image URL
        public string? ImageUrl { get; set; }

        public virtual ICollection<CustomerDiscount> CustomerDiscounts { get; set; } = new List<CustomerDiscount>();

        public string GetInfo() => $"{DiscountName} - {DiscountType}: {DiscountValue}% (Active: {IsActive})";
    }
}
