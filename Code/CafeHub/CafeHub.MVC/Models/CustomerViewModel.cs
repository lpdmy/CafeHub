namespace CafeHub.MVC.Models
{
    public class CustomerViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string ProfilePictureUrl { get; set; }
        public int LoyaltyPoints { get; set; }
        public string MembershipType { get; set; }
        public DateTime JoinDate { get; set; }
       // public List<OrderViewModel> Orders { get; set; } = new List<OrderViewModel>();
    }

   
}
