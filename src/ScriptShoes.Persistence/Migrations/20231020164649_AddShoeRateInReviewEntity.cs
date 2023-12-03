using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddShoeRateInReviewEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfRatings",
                table: "Shoes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "ShoeRate",
                table: "Reviews",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 20, 16, 46, 49, 258, DateTimeKind.Utc).AddTicks(4306), new DateTime(2023, 10, 20, 16, 46, 49, 258, DateTimeKind.Utc).AddTicks(4313) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 20, 16, 46, 49, 258, DateTimeKind.Utc).AddTicks(4314), new DateTime(2023, 10, 20, 16, 46, 49, 258, DateTimeKind.Utc).AddTicks(4315) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfRatings",
                table: "Shoes");

            migrationBuilder.DropColumn(
                name: "ShoeRate",
                table: "Reviews");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 15, 14, 30, 17, 486, DateTimeKind.Utc).AddTicks(8512), new DateTime(2023, 10, 15, 14, 30, 17, 486, DateTimeKind.Utc).AddTicks(8517) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 15, 14, 30, 17, 486, DateTimeKind.Utc).AddTicks(8518), new DateTime(2023, 10, 15, 14, 30, 17, 486, DateTimeKind.Utc).AddTicks(8519) });
        }
    }
}
