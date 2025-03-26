namespace CafeHub.MVC.Models
{
    public class StaffProfileViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string EmployeeCode { get; set; }
        public string Position { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsLocked { get; set; }
    }

}
