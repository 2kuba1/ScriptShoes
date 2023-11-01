using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderSessionIdToOrderAddressEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrdersAddresses");

            migrationBuilder.AddColumn<string>(
                name: "OrderSessionId",
                table: "OrdersAddresses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 11, 1, 13, 7, 56, 457, DateTimeKind.Utc).AddTicks(3125), new DateTime(2023, 11, 1, 13, 7, 56, 457, DateTimeKind.Utc).AddTicks(3128) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 11, 1, 13, 7, 56, 457, DateTimeKind.Utc).AddTicks(3130), new DateTime(2023, 11, 1, 13, 7, 56, 457, DateTimeKind.Utc).AddTicks(3131) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderSessionId",
                table: "OrdersAddresses");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrdersAddresses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 11, 1, 12, 41, 23, 166, DateTimeKind.Utc).AddTicks(7168), new DateTime(2023, 11, 1, 12, 41, 23, 166, DateTimeKind.Utc).AddTicks(7170) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 11, 1, 12, 41, 23, 166, DateTimeKind.Utc).AddTicks(7171), new DateTime(2023, 11, 1, 12, 41, 23, 166, DateTimeKind.Utc).AddTicks(7172) });
        }
    }
}
