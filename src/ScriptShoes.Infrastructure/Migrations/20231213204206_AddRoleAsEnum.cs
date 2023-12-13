using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleAsEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "RoleId1",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 12, 13, 20, 42, 6, 61, DateTimeKind.Utc).AddTicks(1300), new DateTime(2023, 12, 13, 20, 42, 6, 61, DateTimeKind.Utc).AddTicks(1302) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 12, 13, 20, 42, 6, 61, DateTimeKind.Utc).AddTicks(1303), new DateTime(2023, 12, 13, 20, 42, 6, 61, DateTimeKind.Utc).AddTicks(1304) });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId1",
                table: "Users",
                column: "RoleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId1",
                table: "Users",
                column: "RoleId1",
                principalTable: "Roles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 12, 13, 19, 8, 24, 961, DateTimeKind.Utc).AddTicks(1606), new DateTime(2023, 12, 13, 19, 8, 24, 961, DateTimeKind.Utc).AddTicks(1608) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 12, 13, 19, 8, 24, 961, DateTimeKind.Utc).AddTicks(1610), new DateTime(2023, 12, 13, 19, 8, 24, 961, DateTimeKind.Utc).AddTicks(1610) });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
