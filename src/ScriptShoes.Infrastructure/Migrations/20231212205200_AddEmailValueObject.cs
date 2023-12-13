using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailValueObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 12, 12, 20, 52, 0, 80, DateTimeKind.Utc).AddTicks(7207), new DateTime(2023, 12, 12, 20, 52, 0, 80, DateTimeKind.Utc).AddTicks(7208) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 12, 12, 20, 52, 0, 80, DateTimeKind.Utc).AddTicks(7210), new DateTime(2023, 12, 12, 20, 52, 0, 80, DateTimeKind.Utc).AddTicks(7210) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
