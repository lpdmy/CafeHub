using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Commons.Models
{
    public class CustomerDiscount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CustomerId { get; set; } 

        [Required]
        public int DiscountId { get; set; } 

        [Required]
        public DateTime DateGranted { get; set; } = DateTime.Now;

        [Required]
        public bool IsActive { get; set; } = true;

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("DiscountId")]
        public virtual Discount Discount { get; set; }

        public string GetInfo() => $"Customer {CustomerId} - Discount {DiscountId} (Active: {IsActive})";
    }
}
