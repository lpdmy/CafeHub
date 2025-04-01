using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Commons.Models
{
    public class Salary
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string StaffId { get; set; }

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

        [ForeignKey("StaffId")]
        public virtual Staff? Staff { get; set; }

        [NotMapped]
        public decimal NetSalary => BaseSalary + Bonus - Deduction;
        [NotMapped]
        public string StaffName => Staff?.Name ?? "Unknown";
        [NotMapped]
        public decimal TotalSalary => BaseSalary + Bonus * 1000 - Deduction;
        public string GetInfo() => $"Salary for {Staff?.EmployeeCode} - {MonthYear}: {NetSalary:C}";
    }


}
