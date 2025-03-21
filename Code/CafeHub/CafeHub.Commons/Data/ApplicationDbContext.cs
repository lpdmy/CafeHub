﻿using CafeHub.Commons.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CafeHub.Commons
    {
        public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<WorkShift> WorkShifts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Salary> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
