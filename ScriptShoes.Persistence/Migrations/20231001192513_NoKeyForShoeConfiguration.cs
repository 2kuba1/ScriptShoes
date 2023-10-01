using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NoKeyForShoeConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Shoes",
                table: "Shoes");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 1, 19, 25, 13, 248, DateTimeKind.Utc).AddTicks(3816), new DateTime(2023, 10, 1, 19, 25, 13, 248, DateTimeKind.Utc).AddTicks(3818) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 1, 19, 25, 13, 248, DateTimeKind.Utc).AddTicks(3819), new DateTime(2023, 10, 1, 19, 25, 13, 248, DateTimeKind.Utc).AddTicks(3819) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_Shoes",
                table: "Shoes",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 1, 19, 22, 7, 631, DateTimeKind.Utc).AddTicks(5379), new DateTime(2023, 10, 1, 19, 22, 7, 631, DateTimeKind.Utc).AddTicks(5380) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 1, 19, 22, 7, 631, DateTimeKind.Utc).AddTicks(5381), new DateTime(2023, 10, 1, 19, 22, 7, 631, DateTimeKind.Utc).AddTicks(5382) });
        }
    }
}
