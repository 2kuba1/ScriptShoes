using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddVirtualShoeToOrderEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 11, 3, 17, 2, 52, 35, DateTimeKind.Utc).AddTicks(5093), new DateTime(2023, 11, 3, 17, 2, 52, 35, DateTimeKind.Utc).AddTicks(5095) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 11, 3, 17, 2, 52, 35, DateTimeKind.Utc).AddTicks(5097), new DateTime(2023, 11, 3, 17, 2, 52, 35, DateTimeKind.Utc).AddTicks(5097) });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShoeId",
                table: "Orders",
                column: "ShoeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shoes_ShoeId",
                table: "Orders",
                column: "ShoeId",
                principalTable: "Shoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shoes_ShoeId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShoeId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 11, 1, 13, 7, 56, 457, DateTimeKind.Utc).AddTicks(3125), new DateTime(2023, 11, 1, 13, 7, 56, 457, DateTimeKind.Utc).AddTicks(3128) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 11, 1, 13, 7, 56, 457, DateTimeKind.Utc).AddTicks(3130), new DateTime(2023, 11, 1, 13, 7, 56, 457, DateTimeKind.Utc).AddTicks(3131) });
        }
    }
}
