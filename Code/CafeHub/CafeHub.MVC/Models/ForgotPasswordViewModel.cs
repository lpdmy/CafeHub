using System.ComponentModel.DataAnnotations;

namespace CafeHub.MVC.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }

}
