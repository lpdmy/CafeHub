using CafeHub.Commons.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Commons.Models
{
    public class WorkShift
    {
       
        [Key]
        public int Id { get; set; }

        [Required]
        public string ShiftName { get; set; } = string.Empty;

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public DateTime ShiftDate { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<WorkShiftDetail> WorkShiftDetails { get; set; } = new List<WorkShiftDetail>();

        public string GetInfo() => $"{ShiftName} ({ShiftDate:yyyy-MM-dd})";
    }

}
