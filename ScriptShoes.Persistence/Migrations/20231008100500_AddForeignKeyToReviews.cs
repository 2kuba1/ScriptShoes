using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShoeId",
                table: "Reviews",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 8, 10, 5, 0, 856, DateTimeKind.Utc).AddTicks(4954), new DateTime(2023, 10, 8, 10, 5, 0, 856, DateTimeKind.Utc).AddTicks(4956) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 8, 10, 5, 0, 856, DateTimeKind.Utc).AddTicks(4957), new DateTime(2023, 10, 8, 10, 5, 0, 856, DateTimeKind.Utc).AddTicks(4958) });

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_UserId",
                table: "Shoes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ShoeId",
                table: "Reviews",
                column: "ShoeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Shoes_ShoeId",
                table: "Reviews",
                column: "ShoeId",
                principalTable: "Shoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shoes_Users_UserId",
                table: "Shoes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Shoes_ShoeId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Users_UserId",
                table: "Shoes");

            migrationBuilder.DropIndex(
                name: "IX_Shoes_UserId",
                table: "Shoes");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ShoeId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ShoeId",
                table: "Reviews");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 2, 20, 48, 40, 187, DateTimeKind.Utc).AddTicks(3490), new DateTime(2023, 10, 2, 20, 48, 40, 187, DateTimeKind.Utc).AddTicks(3491) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 2, 20, 48, 40, 187, DateTimeKind.Utc).AddTicks(3492), new DateTime(2023, 10, 2, 20, 48, 40, 187, DateTimeKind.Utc).AddTicks(3493) });
        }
    }
}
