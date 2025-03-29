using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CafeHub.Commons.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Toppings_ToppingId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ToppingId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ToppingId",
                table: "OrderItems");

            migrationBuilder.AddColumn<int>(
                name: "IceAmount",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "OrderItems",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SugarAmount",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3242), new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3243) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3250), new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3252) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3257), new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3258) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3687), new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3689) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3701), new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3703) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3709), new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3710) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3715), new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3717) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3722), new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3723) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3794), new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3795) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3802), new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3803) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3808), new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3810) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3815), new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3816) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3828), new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3829) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3834), new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3835) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3841), new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3842) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3847), new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3848) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3854), new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3855) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3860), new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3861) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3866), new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3867) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3873), new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3874) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3882), new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3883) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3888), new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3889) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3894), new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3895) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3901), new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3902) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3907), new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3908) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3913), new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3914) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3919), new DateTime(2025, 3, 28, 18, 49, 40, 455, DateTimeKind.Utc).AddTicks(3920) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IceAmount",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "SugarAmount",
                table: "OrderItems");

            migrationBuilder.AddColumn<int>(
                name: "ToppingId",
                table: "OrderItems",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5469), new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5470) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5477), new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5479) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5484), new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5485) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5871), new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5874) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5884), new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5885) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5891), new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5893) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5898), new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5899) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5913), new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5914) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5928), new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5929) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5935), new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5936) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5942), new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5943) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5948), new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5949) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5957), new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5958) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5964), new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5965) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5972), new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5973) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5978), new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5979) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5985), new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5986) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5992), new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5993) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(5999), new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(6000) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(6006), new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(6007) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(6015), new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(6016) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(6021), new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(6022) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(6027), new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(6028) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(6033), new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(6034) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(6041), new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(6042) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(6047), new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(6048) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(6053), new DateTime(2025, 3, 28, 15, 28, 46, 482, DateTimeKind.Utc).AddTicks(6054) });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ToppingId",
                table: "OrderItems",
                column: "ToppingId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Toppings_ToppingId",
                table: "OrderItems",
                column: "ToppingId",
                principalTable: "Toppings",
                principalColumn: "Id");
        }
    }
}
