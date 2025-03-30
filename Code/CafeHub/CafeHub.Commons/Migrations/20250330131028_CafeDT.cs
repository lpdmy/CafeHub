using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeHub.Commons.Migrations
{
    /// <inheritdoc />
    public partial class CafeDT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7553), new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7554) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7556), new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7557) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7558), new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7559) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7863), new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7864) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7870), new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7870) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7872), new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7873) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7875), new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7876) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7878), new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7878) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7884), new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7884) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7886), new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7886) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7888), new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7889) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7890), new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7891) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7894), new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7894) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7896), new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7897) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7899), new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7899) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7901), new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7902) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7905), new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7905) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7907), new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7908) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7910), new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7910) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7912), new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7912) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7915), new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7915) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7917), new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7918) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7969), new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7969) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7971), new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7971) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7974), new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7974) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7976), new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7976) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7978), new DateTime(2025, 3, 30, 13, 10, 27, 624, DateTimeKind.Utc).AddTicks(7978) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9515), new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9515) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9518), new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9522) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9523), new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9523) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9656), new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9656) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9661), new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9662) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9665), new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9665) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9667), new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9667) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9669), new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9670) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9674), new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9674) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9676), new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9676) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9678), new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9679) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9681), new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9681) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9684), new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9685) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9687), new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9687) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9689), new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9690) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9692), new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9692) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9695), new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9695) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9698), new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9698) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9700), new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9701) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9703), new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9704) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9707), new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9708) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9710), new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9710) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9713), new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9714) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9717), new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9717) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9720), new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9720) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9722), new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9722) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9724), new DateTime(2025, 3, 30, 13, 9, 34, 477, DateTimeKind.Utc).AddTicks(9724) });
        }
    }
}
