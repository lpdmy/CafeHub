using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Commons.Models
{
    public class Admin : User
    {
        public string AdminRole { get; set; } = "Manager";
        public string AccessLevel { get; set; } = "Full";

        public override string GetInfo() => $"Admin: {Name}, Role: Admin, Access: {AccessLevel}";
    }
}
