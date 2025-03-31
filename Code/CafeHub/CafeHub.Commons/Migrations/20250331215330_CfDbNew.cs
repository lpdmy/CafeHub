using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeHub.Commons.Migrations
{
    /// <inheritdoc />
    public partial class CfDbNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(4850), new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(4850) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(4853), new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(4853) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(4855), new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(4855) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(4998), new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5000) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5004), new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5004) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5007), new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5007) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5110), new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5110) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5114), new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5114) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5120), new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5121) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5123), new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5123) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5125), new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5125) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5127), new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5128) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5130), new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5131) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5133), new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5133) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5135), new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5136) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5138), new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5138) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5141), new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5141) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5143), new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5144) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5145), new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5146) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5148), new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5148) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5151), new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5151) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5153), new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5154) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5155), new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5156) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5158), new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5158) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5160), new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5160) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5162), new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5162) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5164), new DateTime(2025, 3, 31, 21, 53, 29, 962, DateTimeKind.Utc).AddTicks(5164) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3794), new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3795) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3798), new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3798) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3799), new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3800) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3939), new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3940) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3944), new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3944) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3946), new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3947) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3949), new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3949) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3951), new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3952) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3956), new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3956) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3985), new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3985) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3987), new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3988) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3990), new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3990) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3993), new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3993) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3995), new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3996) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3997), new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(3998) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(4000), new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(4001) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(4003), new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(4004) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(4006), new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(4006) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(4008), new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(4008) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(4010), new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(4011) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(4013), new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(4014) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(4015), new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(4016) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(4018), new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(4018) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(4020), new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(4020) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(4022), new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(4022) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(4024), new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(4024) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(4026), new DateTime(2025, 3, 31, 21, 49, 9, 677, DateTimeKind.Utc).AddTicks(4027) });
        }
    }
}
