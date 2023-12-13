using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddHashedPasswordValueObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 12, 11, 11, 47, 26, 771, DateTimeKind.Utc).AddTicks(5483), new DateTime(2023, 12, 11, 11, 47, 26, 771, DateTimeKind.Utc).AddTicks(5484) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 12, 11, 11, 47, 26, 771, DateTimeKind.Utc).AddTicks(5486), new DateTime(2023, 12, 11, 11, 47, 26, 771, DateTimeKind.Utc).AddTicks(5486) });
        }
    }
}
