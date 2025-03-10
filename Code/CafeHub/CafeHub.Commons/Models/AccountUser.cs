using CafeHub.Commons.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Commons.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public RoleEnum Role { get; set; }
        public bool Authenticate { get; set; }
    }

}
