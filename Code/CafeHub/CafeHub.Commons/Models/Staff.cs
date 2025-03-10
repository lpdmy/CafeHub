using CafeHub.Commons.Enums;
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
        [Key]
        public int Id { get; set; }
        public PositionEnum Position { get; set; }
        public decimal FixedSalary { get; set; }
        public SalaryTypeEnum SalaryType { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }

}
