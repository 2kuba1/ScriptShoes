using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUsernameToReviewEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Reviews",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 20, 19, 22, 26, 887, DateTimeKind.Utc).AddTicks(220), new DateTime(2023, 10, 20, 19, 22, 26, 887, DateTimeKind.Utc).AddTicks(222) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 20, 19, 22, 26, 887, DateTimeKind.Utc).AddTicks(225), new DateTime(2023, 10, 20, 19, 22, 26, 887, DateTimeKind.Utc).AddTicks(225) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Reviews");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 20, 16, 46, 49, 258, DateTimeKind.Utc).AddTicks(4306), new DateTime(2023, 10, 20, 16, 46, 49, 258, DateTimeKind.Utc).AddTicks(4313) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 20, 16, 46, 49, 258, DateTimeKind.Utc).AddTicks(4314), new DateTime(2023, 10, 20, 16, 46, 49, 258, DateTimeKind.Utc).AddTicks(4315) });
        }
    }
}
