using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CafeHub.Commons.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductsAndCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Description", "ImagePath", "IsActive", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9557), "All coffee-based drinks", "/images/menu-image-1.jpg", true, "Our original coffee", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9557) },
                    { 2, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9561), "A variety of tea options", "/images/menu-image-2.jpg", true, "Our tea & bread", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9561) },
                    { 3, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9564), "Delicious bakery items", "/images/menu-image-3.jpg", true, "Our pastries & cravings", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9564) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "ImagePath", "IsAvailable", "Name", "Price", "Size", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9752), "Freshly Brewed Coffee Blended with Rich, Velvety Steamed Milk for a Perfectly Balanced Cup.", "/images/original-coffee-img-1.png", true, "White Chocolate", 26.00m, "Medium", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9753) },
                    { 2, 1, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9758), "Smooth Condensed Milk Combined with Chilled Ice Cubes and Bold, Flavorful Espresso for a Refreshing Treat.", "/images/original-coffee-img-2.png", true, "Colombia Dark Roast", 20.00m, "Large", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9759) },
                    { 3, 1, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9763), "Rich Espresso Blended with Smooth Vanilla-Flavored Syrup and Creamy Milk, Creating a Perfectly Balanced Delight.", "/images/original-coffee-img-3.png", true, "Iced Caramel Latte", 24.00m, "Medium", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9763) },
                    { 4, 1, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9766), "Freshly Brewed Coffee Combined with Bold Espresso, Delivering a Perfectly Balanced and Rich Flavor Experience.", "/images/original-coffee-img-4.png", true, "Espresso Macchiato", 30.00m, "Small", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9767) },
                    { 5, 1, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9770), "A bold and intense coffee with deep flavors, perfect for those who enjoy a strong cup.", "/images/original-coffee-img-5.png", true, "Robusta", 16.00m, "Medium", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9770) },
                    { 6, 1, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9777), "Smooth and aromatic coffee, known for its balanced taste and delightful fragrance.", "/images/original-coffee-img-6.png", true, "Arabica Coffee", 20.00m, "Large", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9777) },
                    { 7, 1, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9780), "Rich, full-bodied coffee with a deep roast, bringing out a smoky and chocolatey essence.", "/images/original-coffee-img-7.png", true, "Colombia Dark Roast", 22.00m, "Medium", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9780) },
                    { 8, 1, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9783), "A smooth, light-bodied coffee with a rich espresso base, perfect for those who enjoy a milder taste.", "/images/original-coffee-img-8.png", true, "Americano Coffee", 32.00m, "Large", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9783) },
                    { 9, 1, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9786), "A rich blend of mocha and green tea, balancing sweetness and earthiness for a delightful taste.", "~/images/tea-bread-image-1.png", true, "Mocha Green Tea", 26.00m, "Medium", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9786) },
                    { 10, 1, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9790), "Bold and aromatic with a hint of spice, often enjoyed with milk for a creamy finish.", "~/images/tea-bread-image-2.png", true, "Black Thai Tea", 20.00m, "Medium", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9791) },
                    { 11, 1, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9793), "A sweet, comforting tea with a rich caramel flavor, offering a velvety and warm experience.", "~/images/tea-bread-image-3.png", true, "Cold Brew Tea", 18.00m, "Large", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9794) },
                    { 12, 1, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9796), "A crispy, golden loaf with a rich caramel flavor and a touch of herbs, perfect as a side or snack.", "~/images/tea-bread-image-4.png", true, "Caramel Tea", 12.00m, "Small", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9797) },
                    { 13, 2, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9800), "A classic French bread with a golden, crunchy crust and a soft, airy interior, ideal for sandwiches or serving with soup.", "~/images/tea-bread-image-5.png", true, "Garlic Bread", 15.00m, "Large", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9800) },
                    { 14, 2, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9803), "A sweet, spiced loaf filled with cinnamon swirls, offering a comforting aroma, perfect for breakfast or a treat.", "~/images/tea-bread-image-6.png", true, "Baguette", 16.00m, "Large", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9803) },
                    { 15, 2, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9807), "A perfect pairing of crispy, freshly made chips and rich, flavorful dips that bring a burst of taste in every bite.", "~/images/tea-bread-image-7.png", true, "Cinnamon Bread", 22.00m, "Medium", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9807) },
                    { 16, 2, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9810), "A hearty, wholesome bread made from whole wheat flour, rich in fiber and nutrients for a healthy option.", "~/images/tea-bread-image-8.png", true, "Whole Wheat Bread", 28.00m, "Medium", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9810) },
                    { 17, 3, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9813), "A perfect pairing of crispy, freshly made chips and rich, flavorful dips.", "/images/dessert-image-3.png", true, "Almond Croissant", 22.00m, "Medium", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9813) },
                    { 18, 3, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9817), "A light, flaky pastry topped with fresh mixed berries.", "/images/dessert-image-2.png", true, "Berry Danish", 20.00m, "Medium", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9817) },
                    { 19, 3, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9823), "A classic French pastry filled with creamy custard and chocolate.", "/images/dessert-image-3.png", true, "Chocolate Eclair", 24.00m, "Medium", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9823) },
                    { 20, 3, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9826), "A warm, soft bun swirled with cinnamon and sugar.", "/images/dessert-image-4.png", true, "Cinnamon Bun", 30.00m, "Large", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9826) },
                    { 21, 3, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9829), "Rich, fudgy brownies swirled with creamy caramel.", "/images/dessert-image-5.png", true, "Caramel Brownie", 26.00m, "Medium", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9829) },
                    { 22, 3, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9832), "Classic soft cookies loaded with gooey chocolate chips.", "/images/dessert-image-6.png", true, "Choco Chip Cookies", 22.00m, "Small", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9832) },
                    { 23, 3, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9835), "A tangy and creamy cheesecake with zesty lemon flavor.", "/images/dessert-image-7.png", true, "Lemon Cheesecake", 32.00m, "Large", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9835) },
                    { 24, 3, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9838), "A crisp tart filled with sweet peach filling.", "/images/dessert-image-8.png", true, "Peach Tart", 20.00m, "Medium", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9838) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
