using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Commons.Models
{
    public class Salary
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentData { get; set; }
        public Staff Staff { get; set; }
    }

}
