using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddLastNameValueObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 12, 13, 17, 58, 6, 116, DateTimeKind.Utc).AddTicks(7343), new DateTime(2023, 12, 13, 17, 58, 6, 116, DateTimeKind.Utc).AddTicks(7345) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 12, 13, 17, 58, 6, 116, DateTimeKind.Utc).AddTicks(7346), new DateTime(2023, 12, 13, 17, 58, 6, 116, DateTimeKind.Utc).AddTicks(7346) });
        }
    }
}
