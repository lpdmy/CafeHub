using CafeHub.Commons.Models;
using System.ComponentModel.DataAnnotations;

namespace CafeHub.MVC.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        [Required]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        public List<OrderItemViewModel> OrderItems { get; set; } = new();

        [Required]
        public decimal TotalAmount { get; set; }

       
        public Payment? Payment { get; set; }
    }
}
