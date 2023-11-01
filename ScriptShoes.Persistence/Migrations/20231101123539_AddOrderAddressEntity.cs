using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderAddressEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 11, 1, 12, 35, 39, 479, DateTimeKind.Utc).AddTicks(5046), new DateTime(2023, 11, 1, 12, 35, 39, 479, DateTimeKind.Utc).AddTicks(5049) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 11, 1, 12, 35, 39, 479, DateTimeKind.Utc).AddTicks(5050), new DateTime(2023, 11, 1, 12, 35, 39, 479, DateTimeKind.Utc).AddTicks(5051) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 31, 14, 27, 40, 296, DateTimeKind.Utc).AddTicks(6534), new DateTime(2023, 10, 31, 14, 27, 40, 296, DateTimeKind.Utc).AddTicks(6536) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 31, 14, 27, 40, 296, DateTimeKind.Utc).AddTicks(6561), new DateTime(2023, 10, 31, 14, 27, 40, 296, DateTimeKind.Utc).AddTicks(6561) });
        }
    }
}
