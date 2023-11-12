using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnusedFieldInShoeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfRatings",
                table: "Shoes");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 11, 12, 10, 5, 23, 720, DateTimeKind.Utc).AddTicks(7716), new DateTime(2023, 11, 12, 10, 5, 23, 720, DateTimeKind.Utc).AddTicks(7718) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 11, 12, 10, 5, 23, 720, DateTimeKind.Utc).AddTicks(7720), new DateTime(2023, 11, 12, 10, 5, 23, 720, DateTimeKind.Utc).AddTicks(7720) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfRatings",
                table: "Shoes",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 11, 12, 8, 57, 56, 780, DateTimeKind.Utc).AddTicks(6800), new DateTime(2023, 11, 12, 8, 57, 56, 780, DateTimeKind.Utc).AddTicks(6801) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 11, 12, 8, 57, 56, 780, DateTimeKind.Utc).AddTicks(6803), new DateTime(2023, 11, 12, 8, 57, 56, 780, DateTimeKind.Utc).AddTicks(6803) });
        }
    }
}
