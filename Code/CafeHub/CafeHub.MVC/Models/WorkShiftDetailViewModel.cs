﻿using System.ComponentModel.DataAnnotations;

namespace CafeHub.MVC.Models
{
    public class WorkShiftDetailViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string StaffId { get; set; }

        [Required]
        public int WorkShiftId { get; set; }

        [Required]
        public string AttendanceStatus { get; set; } = "Present";

        public string? Notes { get; set; }

        // Thêm hai thuộc tính mới
        public string? StaffName { get; set; }
        public string? WorkShiftName { get; set; }
    }
}
