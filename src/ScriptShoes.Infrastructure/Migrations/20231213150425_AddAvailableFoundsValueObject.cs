using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAvailableFoundsValueObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "AvailableFounds",
                table: "Users",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "AvailableFounds",
                table: "Users",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

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
    }
}
