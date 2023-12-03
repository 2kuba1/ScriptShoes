using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDiscountEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentPrice",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "PriceBeforeDiscount",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "ShoeId",
                table: "Discounts");

            migrationBuilder.AddColumn<int>(
                name: "DiscountPercentage",
                table: "Discounts",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DiscountStartTime",
                table: "Discounts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<float>(
                name: "MoneyDiscount",
                table: "Discounts",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<List<int>>(
                name: "ShoesIds",
                table: "Discounts",
                type: "integer[]",
                nullable: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 11, 14, 17, 36, 44, 79, DateTimeKind.Utc).AddTicks(1112), new DateTime(2023, 11, 14, 17, 36, 44, 79, DateTimeKind.Utc).AddTicks(1114) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 11, 14, 17, 36, 44, 79, DateTimeKind.Utc).AddTicks(1116), new DateTime(2023, 11, 14, 17, 36, 44, 79, DateTimeKind.Utc).AddTicks(1116) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPercentage",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "DiscountStartTime",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "MoneyDiscount",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "ShoesIds",
                table: "Discounts");

            migrationBuilder.AddColumn<float>(
                name: "CurrentPrice",
                table: "Discounts",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PriceBeforeDiscount",
                table: "Discounts",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "ShoeId",
                table: "Discounts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 11, 13, 19, 27, 45, 614, DateTimeKind.Utc).AddTicks(6454), new DateTime(2023, 11, 13, 19, 27, 45, 614, DateTimeKind.Utc).AddTicks(6459) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 11, 13, 19, 27, 45, 614, DateTimeKind.Utc).AddTicks(6461), new DateTime(2023, 11, 13, 19, 27, 45, 614, DateTimeKind.Utc).AddTicks(6461) });
        }
    }
}
