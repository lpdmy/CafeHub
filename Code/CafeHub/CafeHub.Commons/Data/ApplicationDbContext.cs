using CafeHub.Commons.Models;
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
        public DbSet<Admin> Admins { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<User> ApplicationUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerDiscount> CustomerDiscounts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductTopping> ProductToppings { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<WorkShift> WorkShifts { get; set; }
        public DbSet<WorkShiftDetail> WorkShiftDetails { get; set; }
    }
}
