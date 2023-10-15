using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCartEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "AmountOfMoney",
                table: "Carts",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "ItemsCount",
                table: "Carts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 15, 10, 13, 51, 86, DateTimeKind.Utc).AddTicks(1046), new DateTime(2023, 10, 15, 10, 13, 51, 86, DateTimeKind.Utc).AddTicks(1047) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 15, 10, 13, 51, 86, DateTimeKind.Utc).AddTicks(1049), new DateTime(2023, 10, 15, 10, 13, 51, 86, DateTimeKind.Utc).AddTicks(1049) });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ShoeId",
                table: "Carts",
                column: "ShoeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Shoes_ShoeId",
                table: "Carts",
                column: "ShoeId",
                principalTable: "Shoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Shoes_ShoeId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_ShoeId",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "AmountOfMoney",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "ItemsCount",
                table: "Carts");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 14, 17, 50, 36, 297, DateTimeKind.Utc).AddTicks(7374), new DateTime(2023, 10, 14, 17, 50, 36, 297, DateTimeKind.Utc).AddTicks(7375) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 14, 17, 50, 36, 297, DateTimeKind.Utc).AddTicks(7377), new DateTime(2023, 10, 14, 17, 50, 36, 297, DateTimeKind.Utc).AddTicks(7378) });
        }
    }
}
