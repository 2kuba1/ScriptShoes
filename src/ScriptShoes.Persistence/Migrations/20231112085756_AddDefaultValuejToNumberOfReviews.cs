using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultValuejToNumberOfReviews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NumberOfReviews",
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
                values: new object[] { new DateTime(2023, 11, 12, 8, 57, 56, 780, DateTimeKind.Utc).AddTicks(6800), new DateTime(2023, 11, 12, 8, 57, 56, 780, DateTimeKind.Utc).AddTicks(6801) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 11, 12, 8, 57, 56, 780, DateTimeKind.Utc).AddTicks(6803), new DateTime(2023, 11, 12, 8, 57, 56, 780, DateTimeKind.Utc).AddTicks(6803) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NumberOfReviews",
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
                values: new object[] { new DateTime(2023, 11, 4, 11, 22, 8, 465, DateTimeKind.Utc).AddTicks(664), new DateTime(2023, 11, 4, 11, 22, 8, 465, DateTimeKind.Utc).AddTicks(667) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 11, 4, 11, 22, 8, 465, DateTimeKind.Utc).AddTicks(668), new DateTime(2023, 11, 4, 11, 22, 8, 465, DateTimeKind.Utc).AddTicks(668) });
        }
    }
}
