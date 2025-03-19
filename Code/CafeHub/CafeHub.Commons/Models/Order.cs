using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Commons.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public Customer Customer { get; set; }

        public IEnumerable<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public decimal CalculateTotal() => TotalAmount;
    }

}
