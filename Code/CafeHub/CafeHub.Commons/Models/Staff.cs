    using CafeHub.Commons.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Commons.Models
{
    public class Staff : User
    {
        [Required]
        public string EmployeeCode { get; set; } = string.Empty;

        [Required]
        public string Position { get; set; } = string.Empty;

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        public decimal Salary { get; set; }

        public virtual ICollection<WorkShiftDetail> WorkShiftDetails { get; set; } = new List<WorkShiftDetail>();

        public virtual ICollection<Salary> Salaries { get; set; } = new List<Salary>();

        public string GetInfo() => $"{EmployeeCode} - {Position}";
        public virtual ICollection<Order> OrdersProcessed { get; set; } = new List<Order>();
    }

}
