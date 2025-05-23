﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeHub.Commons.Models
{
    public class Customer : User
    {
        // Thông tin cá nhân
        public string FullName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public string Gender { get; set; } = "Unspecified"; // Male, Female, Other
        public string Address { get; set; } = string.Empty;
        public string ProfilePictureUrl { get; set; } = string.Empty;
        public int LoyaltyPoints { get; set; } = 0;
        // Computed property to determine rank
        public string MembershipType
        {
            get
            {
                if (LoyaltyPoints >= 1000) return "Platinum";
                if (LoyaltyPoints >= 500) return "Gold";
                if (LoyaltyPoints >= 100) return "Silver";
                return "Bronze";
            }
        }
        
        public DateTime JoinDate { get; set; } = DateTime.UtcNow;

        public override string GetInfo() => $"Customer: {Name}, Role: Customer, Points: {LoyaltyPoints}";
        public virtual ICollection<CustomerDiscount> CustomerDiscounts { get; set; } = new List<CustomerDiscount>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }


}
