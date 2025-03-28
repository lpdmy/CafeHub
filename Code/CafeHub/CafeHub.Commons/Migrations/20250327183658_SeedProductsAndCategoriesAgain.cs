using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeHub.Commons.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductsAndCategoriesAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1172), new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1173) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1246), new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1246) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1250), new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1251) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1536), new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1536) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1545), new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1546) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1550), new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1551) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1556), new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1556) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1560), new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1561) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1571), new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1571) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1575), new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1576) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1580), new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1581) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CategoryId", "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1585), "~/images/tea-bread-image-1.png", new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1586) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1591), "~/images/tea-bread-image-2.png", new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1592) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CategoryId", "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1596), "~/images/tea-bread-image-3.png", new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1596) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CategoryId", "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1600), "~/images/tea-bread-image-4.png", new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1601) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1605), "~/images/tea-bread-image-5.png", new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1606) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1610), "~/images/tea-bread-image-6.png", new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1610) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1614), "~/images/tea-bread-image-7.png", new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1615) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1619), "~/images/tea-bread-image-8.png", new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1620) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1624), new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1624) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1629), new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1630) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1633), new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1634) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1639), new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1639) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1643), new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1643) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1647), new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1648) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1651), new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1652) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1655), new DateTime(2025, 3, 27, 18, 36, 57, 735, DateTimeKind.Utc).AddTicks(1656) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9557), new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9557) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9561), new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9561) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9564), new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9564) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9752), new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9753) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9758), new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9759) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9763), new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9763) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9766), new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9767) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9770), new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9770) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9777), new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9777) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9780), new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9780) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9783), new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9783) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CategoryId", "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9786), "/images/tea-bread-image-1.png", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9786) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9790), "/images/tea-bread-image-2.png", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9791) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CategoryId", "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9793), "/images/tea-bread-image-3.png", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9794) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CategoryId", "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9796), "/images/tea-bread-image-4.png", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9797) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9800), "/images/tea-bread-image-5.png", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9800) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9803), "/images/tea-bread-image-6.png", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9803) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9807), "/images/tea-bread-image-7.png", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9807) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9810), "/images/tea-bread-image-8.png", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9810) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9813), new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9813) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9817), new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9817) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9823), new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9823) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9826), new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9826) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9829), new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9829) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9832), new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9832) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9835), new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9835) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9838), new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9838) });
        }
    }
}
