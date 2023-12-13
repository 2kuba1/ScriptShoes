using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SmallChangesInUserAndRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 12, 13, 20, 52, 22, 41, DateTimeKind.Utc).AddTicks(3734), new DateTime(2023, 12, 13, 20, 52, 22, 41, DateTimeKind.Utc).AddTicks(3735) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 12, 13, 20, 52, 22, 41, DateTimeKind.Utc).AddTicks(3736), new DateTime(2023, 12, 13, 20, 52, 22, 41, DateTimeKind.Utc).AddTicks(3737) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
