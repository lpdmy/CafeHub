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


        [Required(ErrorMessage = "Please select a payment method")]
        public string PaymentMethod { get; set; } = "Cash";


        // Discount selection
        public int? SelectedDiscountId { get; set; } // ID of the selected discount
        public List<DiscountViewModel> AvailableDiscounts { get; set; } = new List<DiscountViewModel>();

    }
}