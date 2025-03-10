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
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ShiftStatusEnum Status { get; set; }
        public string Note { get; set; }

        // Relationship
        public string StaffId { get; set; }
        public Staff Staff { get; set; }
    }

}
