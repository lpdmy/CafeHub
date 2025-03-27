using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeHub.Commons.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductsAndCategoriesAgain1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8355), new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8356) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8360), new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8361) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8364), new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8364) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8609), new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8609) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8616), new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8617) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8621), new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8621) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8624), new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8625) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8628), new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8629) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8639), new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8639) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8643), new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8643) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8647), new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8647) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CategoryId", "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8650), "/images/tea-bread-image-1.png", new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8651) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8656), "/images/tea-bread-image-2.png", new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8657) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CategoryId", "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8660), "/images/tea-bread-image-3.png", new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8660) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CategoryId", "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { 2, new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8663), "/images/tea-bread-image-4.png", new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8664) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8667), "/images/tea-bread-image-5.png", new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8668) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8671), "/images/tea-bread-image-6.png", new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8671) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8674), "/images/tea-bread-image-7.png", new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8675) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8678), "/images/tea-bread-image-8.png", new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8679) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8682), new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8682) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8725), new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8726) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8729), new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8729) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8733), new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8733) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8736), new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8737) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8740), new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8740) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8743), new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8744) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8747), new DateTime(2025, 3, 27, 18, 39, 18, 806, DateTimeKind.Utc).AddTicks(8747) });
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
                values: new object[] { 1, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9786), "~/images/tea-bread-image-1.png", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9786) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9790), "~/images/tea-bread-image-2.png", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9791) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CategoryId", "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9793), "~/images/tea-bread-image-3.png", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9794) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CategoryId", "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9796), "~/images/tea-bread-image-4.png", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9797) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9800), "~/images/tea-bread-image-5.png", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9800) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9803), "~/images/tea-bread-image-6.png", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9803) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9807), "~/images/tea-bread-image-7.png", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9807) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "ImagePath", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9810), "~/images/tea-bread-image-8.png", new DateTime(2025, 3, 27, 18, 15, 8, 284, DateTimeKind.Utc).AddTicks(9810) });

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
