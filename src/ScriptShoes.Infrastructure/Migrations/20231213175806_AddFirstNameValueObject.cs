using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstNameValueObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 12, 13, 15, 4, 24, 953, DateTimeKind.Utc).AddTicks(7538), new DateTime(2023, 12, 13, 15, 4, 24, 953, DateTimeKind.Utc).AddTicks(7540) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 12, 13, 15, 4, 24, 953, DateTimeKind.Utc).AddTicks(7541), new DateTime(2023, 12, 13, 15, 4, 24, 953, DateTimeKind.Utc).AddTicks(7541) });
        }
    }
}
