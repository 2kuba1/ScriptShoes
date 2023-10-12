using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAccessTokenToUserEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TokenExpires",
                table: "Users",
                newName: "RefreshTokenExpirationTime");

            migrationBuilder.RenameColumn(
                name: "TokenCreated",
                table: "Users",
                newName: "AccessTokenExpirationTime");

            migrationBuilder.AddColumn<string>(
                name: "AccessToken",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 12, 18, 32, 13, 960, DateTimeKind.Utc).AddTicks(9008), new DateTime(2023, 10, 12, 18, 32, 13, 960, DateTimeKind.Utc).AddTicks(9010) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 12, 18, 32, 13, 960, DateTimeKind.Utc).AddTicks(9011), new DateTime(2023, 10, 12, 18, 32, 13, 960, DateTimeKind.Utc).AddTicks(9012) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessToken",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "RefreshTokenExpirationTime",
                table: "Users",
                newName: "TokenExpires");

            migrationBuilder.RenameColumn(
                name: "AccessTokenExpirationTime",
                table: "Users",
                newName: "TokenCreated");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 8, 15, 27, 30, 693, DateTimeKind.Utc).AddTicks(7926), new DateTime(2023, 10, 8, 15, 27, 30, 693, DateTimeKind.Utc).AddTicks(7928) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 8, 15, 27, 30, 693, DateTimeKind.Utc).AddTicks(7929), new DateTime(2023, 10, 8, 15, 27, 30, 693, DateTimeKind.Utc).AddTicks(7930) });
        }
    }
}
