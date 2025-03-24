using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Commons.Models
{
    public class WorkShiftDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string StaffId { get; set; }

        [Required]
        public int WorkShiftId { get; set; }

        [Required]
        public string AttendanceStatus { get; set; } = "Present";

        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }

        public decimal OvertimeHours { get; set; }
        public long HoursContributed { get; set; }
        public string? Notes { get; set; }

        [ForeignKey("StaffId")]
        public virtual Staff? Staff { get; set; }

        [ForeignKey("WorkShiftId")]
        public virtual WorkShift? WorkShift { get; set; }

        public string GetInfo() => $"ShiftDetail: {WorkShiftId} - Staff: {StaffId}";
    }
}
