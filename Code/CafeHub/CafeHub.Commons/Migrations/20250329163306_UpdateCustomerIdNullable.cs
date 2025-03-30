using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeHub.Commons.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCustomerIdNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7324), new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7325) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7327), new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7327) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7329), new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7329) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7461), new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7461) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7466), new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7466) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7468), new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7468) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7471), new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7471) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7473), new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7473) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7477), new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7477) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7479), new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7479) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7481), new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7482) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7484), new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7484) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7487), new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7487) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7489), new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7492) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7494), new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7494) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7496), new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7496) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7498), new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7498) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7500), new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7501) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7503), new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7503) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7505), new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7505) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7508), new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7509) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7510), new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7511) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7512), new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7513) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7515), new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7515) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7525), new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7525) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7527), new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7527) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7529), new DateTime(2025, 3, 29, 16, 33, 6, 359, DateTimeKind.Utc).AddTicks(7529) });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "CustomerId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1309), new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1310) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1312), new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1313) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1315), new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1315) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1479), new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1479) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1483), new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1484) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1486), new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1486) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1489), new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1489) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1492), new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1492) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1496), new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1496) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1499), new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1499) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1501), new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1501) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1503), new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1504) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1507), new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1507) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1509), new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1511) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1513), new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1513) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1515), new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1515) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1517), new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1518) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1520), new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1521) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1523), new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1523) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1525), new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1525) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1528), new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1528) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1530), new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1531) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1533), new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1533) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1535), new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1535) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1537), new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1538) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1539), new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1540) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1542), new DateTime(2025, 3, 29, 12, 48, 6, 310, DateTimeKind.Utc).AddTicks(1542) });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
