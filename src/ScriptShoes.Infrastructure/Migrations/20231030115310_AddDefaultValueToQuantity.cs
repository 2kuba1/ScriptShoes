using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultValueToQuantity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Shoes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 30, 11, 53, 10, 126, DateTimeKind.Utc).AddTicks(4137), new DateTime(2023, 10, 30, 11, 53, 10, 126, DateTimeKind.Utc).AddTicks(4139) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 30, 11, 53, 10, 126, DateTimeKind.Utc).AddTicks(4141), new DateTime(2023, 10, 30, 11, 53, 10, 126, DateTimeKind.Utc).AddTicks(4141) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "Shoes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

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
    }
}
