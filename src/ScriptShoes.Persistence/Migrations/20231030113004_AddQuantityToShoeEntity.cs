using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddQuantityToShoeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Shoes",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 30, 11, 30, 4, 804, DateTimeKind.Utc).AddTicks(4678), new DateTime(2023, 10, 30, 11, 30, 4, 804, DateTimeKind.Utc).AddTicks(4680) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 30, 11, 30, 4, 804, DateTimeKind.Utc).AddTicks(4681), new DateTime(2023, 10, 30, 11, 30, 4, 804, DateTimeKind.Utc).AddTicks(4682) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Shoes");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 21, 19, 28, 55, 367, DateTimeKind.Utc).AddTicks(6636), new DateTime(2023, 10, 21, 19, 28, 55, 367, DateTimeKind.Utc).AddTicks(6638) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 21, 19, 28, 55, 367, DateTimeKind.Utc).AddTicks(6639), new DateTime(2023, 10, 21, 19, 28, 55, 367, DateTimeKind.Utc).AddTicks(6639) });
        }
    }
}
