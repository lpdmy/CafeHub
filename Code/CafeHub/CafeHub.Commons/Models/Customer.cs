using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Commons.Models
{
    public class Customer : User
    {
        [Key]
        public int Id { get; set; }
        public int LoyaltyPoints { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }

}
