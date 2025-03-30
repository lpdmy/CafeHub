using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CafeHub.MVC.Models
{
    public class OrderOfflineViewModel
    {
        public List<OrderItemViewModel> OrderItems { get; set; } = new List<OrderItemViewModel>();

        [Required]
        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = "Pending";

       
    }
}