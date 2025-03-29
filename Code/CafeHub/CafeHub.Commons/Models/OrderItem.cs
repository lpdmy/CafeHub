using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Commons.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

       

        [Required]
        [Range(1, 1000)]
        public int Quantity { get; set; }

        [Required]
        public string Size { get; set; } = "Medium";
        [Required]
        public int SugarAmount { get; set; } = 100;
        [Required]
        public int IceAmount { get; set; } = 100;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; } 

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // Navigation Properties
        [ForeignKey("OrderId")]
        public virtual Order? Order { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }

   
        public decimal CalculateItemTotal() => UnitPrice * Quantity;

        public string GetInfo()
        {
            return $"{Quantity} x {Product?.Name} - ${UnitPrice}";
        }
    }
}
