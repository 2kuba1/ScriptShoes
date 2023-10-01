using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveVirtualProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Shoes_ShoeId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Users_UserId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailCodes_Users_UserId",
                table: "EmailCodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Shoes_ShoeId",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Users_UserId",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Shoes_Users_UserId",
                table: "Shoes");

            migrationBuilder.DropIndex(
                name: "IX_Shoes_UserId",
                table: "Shoes");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_ShoeId",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_EmailCodes_UserId",
                table: "EmailCodes");

            migrationBuilder.DropIndex(
                name: "IX_Carts_ShoeId",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_UserId",
                table: "Carts");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 1, 19, 22, 7, 631, DateTimeKind.Utc).AddTicks(5379), new DateTime(2023, 10, 1, 19, 22, 7, 631, DateTimeKind.Utc).AddTicks(5380) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 1, 19, 22, 7, 631, DateTimeKind.Utc).AddTicks(5381), new DateTime(2023, 10, 1, 19, 22, 7, 631, DateTimeKind.Utc).AddTicks(5382) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 1, 14, 44, 17, 369, DateTimeKind.Utc).AddTicks(5970), new DateTime(2023, 10, 1, 14, 44, 17, 369, DateTimeKind.Utc).AddTicks(5973) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 1, 14, 44, 17, 369, DateTimeKind.Utc).AddTicks(5974), new DateTime(2023, 10, 1, 14, 44, 17, 369, DateTimeKind.Utc).AddTicks(5974) });

            migrationBuilder.CreateIndex(
                name: "IX_Shoes_UserId",
                table: "Shoes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_ShoeId",
                table: "Favorites",
                column: "ShoeId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailCodes_UserId",
                table: "EmailCodes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ShoeId",
                table: "Carts",
                column: "ShoeId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Shoes_ShoeId",
                table: "Carts",
                column: "ShoeId",
                principalTable: "Shoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Users_UserId",
                table: "Carts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailCodes_Users_UserId",
                table: "EmailCodes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Shoes_ShoeId",
                table: "Favorites",
                column: "ShoeId",
                principalTable: "Shoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Users_UserId",
                table: "Favorites",
                column: "UserId",
                principalTable: "Users",
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
    }
}
