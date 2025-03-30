using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Commons.Models
{
    public class Order
    {
       
            [Key]
            public int Id { get; set; }

            
            public string? CustomerId { get; set; } // ID khách hàng đặt hàng

            public string? StaffId { get; set; } // Nhân viên xử lý đơn hàng (nullable)

            [Required]
            public DateTime OrderDate { get; set; } = DateTime.UtcNow;

            [Required]
            [Column(TypeName = "decimal(18,2)")]
            public decimal TotalAmount { get; set; }

            [Required]
            [StringLength(50)]
            public string Status { get; set; } = "Pending"; // Pending, Completed, Canceled

            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }

            [ForeignKey("CustomerId")]
            public virtual Customer Customer { get; set; }

            [ForeignKey("StaffId")]
            public virtual Staff? Staff { get; set; }

            public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

            public virtual Payment? Payment { get; set; }

            public string GetInfo()
            {
                return $"Order {Id} - {Status} - ${TotalAmount}";
            }
        }
    }
