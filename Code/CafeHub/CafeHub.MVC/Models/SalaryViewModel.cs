using CafeHub.Commons.Models;
using System.ComponentModel.DataAnnotations;

namespace CafeHub.MVC.Models
{
    public class SalaryViewModel
    {

        public int Id { get; set; }

        [Required]
        public string StaffId { get; set; }
        [Required]
        public string StaffName { get; set; }
        //public string StaffName => Staff?.Name ?? "Unknown";
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Base salary must be positive.")]
        public decimal BaseSalary { get; set; }

        public decimal Bonus { get; set; } = 0;
        public decimal Deduction { get; set; } = 0;

        [Required]
        public DateTime PayDate { get; set; }

        [Required]
        [StringLength(7)]
        public string MonthYear { get; set; } = DateTime.Now.ToString("yyyy-MM");

        public double TotalHoursWorked { get; set; }
        public double OvertimeHours { get; set; }
        public decimal HourlyRate { get; set; }
        public string? Notes { get; set; }
        public decimal TotalSalary { get; set; }
    }
}
