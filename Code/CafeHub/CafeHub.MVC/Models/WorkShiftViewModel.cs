using System.ComponentModel.DataAnnotations;

namespace CafeHub.MVC.Models
{
    public class WorkShiftViewModel
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
    }
}
