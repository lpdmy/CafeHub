using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CafeHub.Commons.Migrations
{
    /// <inheritdoc />
    public partial class NewDatabaseForCF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    AdminRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccessLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoyaltyPoints = table.Column<int>(type: "int", nullable: true),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiscountType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiscountValue = table.Column<float>(type: "real", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Condition = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkShifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShiftDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StaffId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_StaffId",
                        column: x => x.StaffId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BaseSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Bonus = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Deduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MonthYear = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    TotalHoursWorked = table.Column<double>(type: "float", nullable: false),
                    OvertimeHours = table.Column<double>(type: "float", nullable: false),
                    HourlyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salaries_AspNetUsers_StaffId",
                        column: x => x.StaffId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDiscounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiscountId = table.Column<int>(type: "int", nullable: false),
                    DateGranted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDiscounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerDiscounts_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerDiscounts_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkShiftDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WorkShiftId = table.Column<int>(type: "int", nullable: false),
                    AttendanceStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckInTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CheckOutTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OvertimeHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HoursContributed = table.Column<long>(type: "bigint", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShiftDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkShiftDetails_AspNetUsers_StaffId",
                        column: x => x.StaffId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkShiftDetails_WorkShifts_WorkShiftId",
                        column: x => x.WorkShiftId,
                        principalTable: "WorkShifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SugarAmount = table.Column<int>(type: "int", nullable: false),
                    IceAmount = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductToppings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ToppingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductToppings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductToppings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductToppings_Toppings_ToppingId",
                        column: x => x.ToppingId,
                        principalTable: "Toppings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "ImagePath", "IsActive", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9515), "All coffee-based drinks", "/images/menu-image-1.jpg", true, "Our original coffee", new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9515) },
                    { 2, new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9518), "A variety of tea options", "/images/menu-image-2.jpg", true, "Our tea & bread", new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9522) },
                    { 3, new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9523), "Delicious bakery items", "/images/menu-image-3.jpg", true, "Our pastries & cravings", new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9523) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "ImagePath", "IsAvailable", "Name", "Price", "Size", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9656), "Freshly Brewed Coffee Blended with Rich, Velvety Steamed Milk for a Perfectly Balanced Cup.", "/images/original-coffee-img-1.png", true, "White Chocolate", 26.00m, "Medium", new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9656) },
                    { 2, 1, new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9661), "Smooth Condensed Milk Combined with Chilled Ice Cubes and Bold, Flavorful Espresso for a Refreshing Treat.", "/images/original-coffee-img-2.png", true, "Colombia Dark Roast", 20.00m, "Large", new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9662) },
                    { 3, 1, new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9665), "Rich Espresso Blended with Smooth Vanilla-Flavored Syrup and Creamy Milk, Creating a Perfectly Balanced Delight.", "/images/original-coffee-img-3.png", true, "Iced Caramel Latte", 24.00m, "Medium", new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9665) },
                    { 4, 1, new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9667), "Freshly Brewed Coffee Combined with Bold Espresso, Delivering a Perfectly Balanced and Rich Flavor Experience.", "/images/original-coffee-img-4.png", true, "Espresso Macchiato", 30.00m, "Small", new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9667) },
                    { 5, 1, new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9669), "A bold and intense coffee with deep flavors, perfect for those who enjoy a strong cup.", "/images/original-coffee-img-5.png", true, "Robusta", 16.00m, "Medium", new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9670) },
                    { 6, 1, new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9674), "Smooth and aromatic coffee, known for its balanced taste and delightful fragrance.", "/images/original-coffee-img-6.png", true, "Arabica Coffee", 20.00m, "Large", new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9674) },
                    { 7, 1, new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9676), "Rich, full-bodied coffee with a deep roast, bringing out a smoky and chocolatey essence.", "/images/original-coffee-img-7.png", true, "Colombia Dark Roast", 22.00m, "Medium", new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9676) },
                    { 8, 1, new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9678), "A smooth, light-bodied coffee with a rich espresso base, perfect for those who enjoy a milder taste.", "/images/original-coffee-img-8.png", true, "Americano Coffee", 32.00m, "Large", new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9679) },
                    { 9, 2, new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9681), "A rich blend of mocha and green tea, balancing sweetness and earthiness for a delightful taste.", "/images/tea-bread-image-1.png", true, "Mocha Green Tea", 26.00m, "Medium", new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9681) },
                    { 10, 2, new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9684), "Bold and aromatic with a hint of spice, often enjoyed with milk for a creamy finish.", "/images/tea-bread-image-2.png", true, "Black Thai Tea", 20.00m, "Medium", new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9685) },
                    { 11, 2, new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9687), "A sweet, comforting tea with a rich caramel flavor, offering a velvety and warm experience.", "/images/tea-bread-image-3.png", true, "Cold Brew Tea", 18.00m, "Large", new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9687) },
                    { 12, 2, new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9689), "A crispy, golden loaf with a rich caramel flavor and a touch of herbs, perfect as a side or snack.", "/images/tea-bread-image-4.png", true, "Caramel Tea", 12.00m, "Small", new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9690) },
                    { 13, 2, new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9692), "A classic French bread with a golden, crunchy crust and a soft, airy interior, ideal for sandwiches or serving with soup.", "/images/tea-bread-image-5.png", true, "Garlic Bread", 15.00m, "Large", new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9692) },
                    { 14, 2, new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9695), "A sweet, spiced loaf filled with cinnamon swirls, offering a comforting aroma, perfect for breakfast or a treat.", "/images/tea-bread-image-6.png", true, "Baguette", 16.00m, "Large", new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9695) },
                    { 15, 2, new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9698), "A perfect pairing of crispy, freshly made chips and rich, flavorful dips that bring a burst of taste in every bite.", "/images/tea-bread-image-7.png", true, "Cinnamon Bread", 22.00m, "Medium", new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9698) },
                    { 16, 2, new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9700), "A hearty, wholesome bread made from whole wheat flour, rich in fiber and nutrients for a healthy option.", "/images/tea-bread-image-8.png", true, "Whole Wheat Bread", 28.00m, "Medium", new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9701) },
                    { 17, 3, new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9703), "A perfect pairing of crispy, freshly made chips and rich, flavorful dips.", "/images/dessert-image-3.png", true, "Almond Croissant", 22.00m, "Medium", new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9704) },
                    { 18, 3, new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9707), "A light, flaky pastry topped with fresh mixed berries.", "/images/dessert-image-2.png", true, "Berry Danish", 20.00m, "Medium", new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9708) },
                    { 19, 3, new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9710), "A classic French pastry filled with creamy custard and chocolate.", "/images/dessert-image-3.png", true, "Chocolate Eclair", 24.00m, "Medium", new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9710) },
                    { 20, 3, new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9713), "A warm, soft bun swirled with cinnamon and sugar.", "/images/dessert-image-4.png", true, "Cinnamon Bun", 30.00m, "Large", new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9714) },
                    { 21, 3, new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9717), "Rich, fudgy brownies swirled with creamy caramel.", "/images/dessert-image-5.png", true, "Caramel Brownie", 26.00m, "Medium", new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9717) },
                    { 22, 3, new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9720), "Classic soft cookies loaded with gooey chocolate chips.", "/images/dessert-image-6.png", true, "Choco Chip Cookies", 22.00m, "Small", new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9720) },
                    { 23, 3, new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9722), "A tangy and creamy cheesecake with zesty lemon flavor.", "/images/dessert-image-7.png", true, "Lemon Cheesecake", 32.00m, "Large", new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9722) },
                    { 24, 3, new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9724), "A crisp tart filled with sweet peach filling.", "/images/dessert-image-8.png", true, "Peach Tart", 20.00m, "Medium", new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9724) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDiscounts_CustomerId",
                table: "CustomerDiscounts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDiscounts_DiscountId",
                table: "CustomerDiscounts",
                column: "DiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StaffId",
                table: "Orders",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductToppings_ProductId",
                table: "ProductToppings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductToppings_ToppingId",
                table: "ProductToppings",
                column: "ToppingId");

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_StaffId",
                table: "Salaries",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShiftDetails_StaffId",
                table: "WorkShiftDetails",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkShiftDetails_WorkShiftId",
                table: "WorkShiftDetails",
                column: "WorkShiftId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CustomerDiscounts");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ProductToppings");

            migrationBuilder.DropTable(
                name: "Salaries");

            migrationBuilder.DropTable(
                name: "WorkShiftDetails");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Toppings");

            migrationBuilder.DropTable(
                name: "WorkShifts");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
