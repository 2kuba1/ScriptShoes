using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultValueToAvarageRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "AverageRating",
                table: "Shoes",
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
                values: new object[] { new DateTime(2023, 11, 12, 10, 13, 17, 562, DateTimeKind.Utc).AddTicks(5459), new DateTime(2023, 11, 12, 10, 13, 17, 562, DateTimeKind.Utc).AddTicks(5461) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 11, 12, 10, 13, 17, 562, DateTimeKind.Utc).AddTicks(5462), new DateTime(2023, 11, 12, 10, 13, 17, 562, DateTimeKind.Utc).AddTicks(5463) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "AverageRating",
                table: "Shoes",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 11, 12, 10, 5, 23, 720, DateTimeKind.Utc).AddTicks(7716), new DateTime(2023, 11, 12, 10, 5, 23, 720, DateTimeKind.Utc).AddTicks(7718) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 11, 12, 10, 5, 23, 720, DateTimeKind.Utc).AddTicks(7720), new DateTime(2023, 11, 12, 10, 5, 23, 720, DateTimeKind.Utc).AddTicks(7720) });
        }
    }
}
