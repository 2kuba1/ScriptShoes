using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixFirstNameField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirsName",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 12, 11, 20, 48, 16, 156, DateTimeKind.Utc).AddTicks(219), new DateTime(2023, 12, 11, 20, 48, 16, 156, DateTimeKind.Utc).AddTicks(222) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 12, 11, 20, 48, 16, 156, DateTimeKind.Utc).AddTicks(223), new DateTime(2023, 12, 11, 20, 48, 16, 156, DateTimeKind.Utc).AddTicks(223) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Users",
                newName: "FirsName");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 12, 11, 20, 30, 35, 297, DateTimeKind.Utc).AddTicks(4754), new DateTime(2023, 12, 11, 20, 30, 35, 297, DateTimeKind.Utc).AddTicks(4756) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 12, 11, 20, 30, 35, 297, DateTimeKind.Utc).AddTicks(4758), new DateTime(2023, 12, 11, 20, 30, 35, 297, DateTimeKind.Utc).AddTicks(4758) });
        }
    }
}
