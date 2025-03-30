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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Our original coffee",
                    Description = "All coffee-based drinks",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ImagePath = "/images/menu-image-1.jpg"
                },
                new Category
                {
                    Id = 2,
                    Name = "Our tea & bread",
                    Description = "A variety of tea options",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ImagePath = "/images/menu-image-2.jpg"
                },
                new Category
                {
                    Id = 3,
                    Name = "Our pastries & cravings",
                    Description = "Delicious bakery items",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ImagePath = "/images/menu-image-3.jpg"
                }
            );
            var products = new List<Product>
        {
            new Product
            {
                Id =1,
                Name = "White Chocolate",
                Description = "Freshly Brewed Coffee Blended with Rich, Velvety Steamed Milk for a Perfectly Balanced Cup.",
                Price = 26.00m,
                Size = "Medium",
                CategoryId = 1, // Coffee
                IsAvailable = true,
                ImagePath = "/images/original-coffee-img-1.png",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Product
            {
                Id = 2,
                Name = "Colombia Dark Roast",
                Description = "Smooth Condensed Milk Combined with Chilled Ice Cubes and Bold, Flavorful Espresso for a Refreshing Treat.",
                Price = 20.00m,
                Size = "Large",
                CategoryId = 1,
                IsAvailable = true,
                ImagePath = "/images/original-coffee-img-2.png",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Product
            {
                Id = 3,
                Name = "Iced Caramel Latte",
                Description = "Rich Espresso Blended with Smooth Vanilla-Flavored Syrup and Creamy Milk, Creating a Perfectly Balanced Delight.",
                Price = 24.00m,
                Size = "Medium",
                CategoryId = 1,
                IsAvailable = true,
                ImagePath = "/images/original-coffee-img-3.png",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Product
            {
                Id = 4,
                Name = "Espresso Macchiato",
                Description = "Freshly Brewed Coffee Combined with Bold Espresso, Delivering a Perfectly Balanced and Rich Flavor Experience.",
                Price = 30.00m,
                Size = "Small",
                CategoryId = 1,
                IsAvailable = true,
                ImagePath = "/images/original-coffee-img-4.png",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Product
            {
                Id = 5,
                Name = "Robusta",
                Description = "A bold and intense coffee with deep flavors, perfect for those who enjoy a strong cup.",
                Price = 16.00m,
                Size = "Medium",
                CategoryId = 1,
                IsAvailable = true,
                ImagePath = "/images/original-coffee-img-5.png",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Product
            {
                Id = 6,
                Name = "Arabica Coffee",
                Description = "Smooth and aromatic coffee, known for its balanced taste and delightful fragrance.",
                Price = 20.00m,
                Size = "Large",
                CategoryId = 1,
                IsAvailable = true,
                ImagePath = "/images/original-coffee-img-6.png",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Product
            {
                Id = 7,
                Name = "Colombia Dark Roast",
                Description = "Rich, full-bodied coffee with a deep roast, bringing out a smoky and chocolatey essence.",
                Price = 22.00m,
                Size = "Medium",
                CategoryId = 1,
                IsAvailable = true,
                ImagePath = "/images/original-coffee-img-7.png",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },
            new Product
            {
                Id = 8,
                Name = "Americano Coffee",
                Description = "A smooth, light-bodied coffee with a rich espresso base, perfect for those who enjoy a milder taste.",
                Price = 32.00m,
                Size = "Large",
                CategoryId = 1,
                IsAvailable = true,
                ImagePath = "/images/original-coffee-img-8.png",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            },

            new Product
                {
                Id = 9,
                    Name = "Mocha Green Tea",
                    Price = 26.00m,
                    Description = "A rich blend of mocha and green tea, balancing sweetness and earthiness for a delightful taste.",
                    Size = "Medium",
                    CategoryId = 2,
                    IsAvailable = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ImagePath = "/images/tea-bread-image-1.png"
                },
                new Product
                {
                    Id = 10,
                    Name = "Black Thai Tea",
                    Price = 20.00m,
                    Description = "Bold and aromatic with a hint of spice, often enjoyed with milk for a creamy finish.",
                    Size = "Medium",
                    CategoryId = 2,
                    IsAvailable = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ImagePath = "/images/tea-bread-image-2.png"
                },
                new Product
                {
                        Id = 11,
                    Name = "Cold Brew Tea",
                    Price = 18.00m,
                    Description = "A sweet, comforting tea with a rich caramel flavor, offering a velvety and warm experience.",
                    Size = "Large",
                    CategoryId = 2,
                    IsAvailable = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ImagePath = "/images/tea-bread-image-3.png"
                },
                new Product
                {
                    Id = 12,
                    Name = "Caramel Tea",
                    Price = 12.00m,
                    Description = "A crispy, golden loaf with a rich caramel flavor and a touch of herbs, perfect as a side or snack.",
                    Size = "Small",
                    CategoryId = 2,
                    IsAvailable = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ImagePath = "/images/tea-bread-image-4.png"
                },
                new Product
                {
                    Id = 13,
                    Name = "Garlic Bread",
                    Price = 15.00m,
                    Description = "A classic French bread with a golden, crunchy crust and a soft, airy interior, ideal for sandwiches or serving with soup.",
                    Size = "Large",
                    CategoryId = 2,
                    IsAvailable = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ImagePath = "/images/tea-bread-image-5.png"
                },
                new Product
                {
                    Id = 14,
                    Name = "Baguette",
                    Price = 16.00m,
                    Description = "A sweet, spiced loaf filled with cinnamon swirls, offering a comforting aroma, perfect for breakfast or a treat.",
                    Size = "Large",
                    CategoryId = 2,
                    IsAvailable = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ImagePath = "/images/tea-bread-image-6.png"
                },
                new Product
                {
                    Id = 15,
                    Name = "Cinnamon Bread",
                    Price = 22.00m,
                    Description = "A perfect pairing of crispy, freshly made chips and rich, flavorful dips that bring a burst of taste in every bite.",
                    Size = "Medium",
                    CategoryId = 2,
                    IsAvailable = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ImagePath = "/images/tea-bread-image-7.png"
                },
                new Product
                {
                    Id = 16,
                    Name = "Whole Wheat Bread",
                    Price = 28.00m,
                    Description = "A hearty, wholesome bread made from whole wheat flour, rich in fiber and nutrients for a healthy option.",
                    Size = "Medium",
                    CategoryId = 2,
                    IsAvailable = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    ImagePath = "/images/tea-bread-image-8.png"
                },
                new Product { Id = 17, Name = "Almond Croissant", Price = 22.00m, Size = "Medium", Description = "A perfect pairing of crispy, freshly made chips and rich, flavorful dips.", CategoryId = 3, ImagePath = "/images/dessert-image-3.png", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Product {Id = 18, Name = "Berry Danish", Price = 20.00m, Size = "Medium", Description = "A light, flaky pastry topped with fresh mixed berries.", CategoryId = 3, ImagePath = "/images/dessert-image-2.png", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Product { Id = 19, Name = "Chocolate Eclair", Price = 24.00m, Size = "Medium", Description = "A classic French pastry filled with creamy custard and chocolate.",  CategoryId = 3, ImagePath = "/images/dessert-image-3.png", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Product { Id = 20,Name = "Cinnamon Bun", Price = 30.00m, Size = "Large", Description = "A warm, soft bun swirled with cinnamon and sugar.", CategoryId = 3, ImagePath = "/images/dessert-image-4.png", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Product { Id = 21, Name = "Caramel Brownie", Price = 26.00m, Size = "Medium", Description = "Rich, fudgy brownies swirled with creamy caramel.", CategoryId = 3, ImagePath = "/images/dessert-image-5.png", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Product { Id = 22, Name = "Choco Chip Cookies", Price = 22.00m, Size = "Small", Description = "Classic soft cookies loaded with gooey chocolate chips.", CategoryId = 3, ImagePath = "/images/dessert-image-6.png", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Product { Id = 23,Name = "Lemon Cheesecake", Price = 32.00m, Size = "Large", Description = "A tangy and creamy cheesecake with zesty lemon flavor.", CategoryId = 3, ImagePath = "/images/dessert-image-7.png", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
            new Product { Id = 24, Name = "Peach Tart", Price = 20.00m, Size = "Medium", Description = "A crisp tart filled with sweet peach filling.", CategoryId = 3, ImagePath = "/images/dessert-image-8.png", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
        };

            modelBuilder.Entity<Product>().HasData(products);
     
        }
    }
}
