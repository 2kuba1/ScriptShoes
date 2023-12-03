using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddShoeIdToReviewLikeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShoeId",
                table: "ReviewsLikes",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 21, 19, 28, 55, 367, DateTimeKind.Utc).AddTicks(6636), new DateTime(2023, 10, 21, 19, 28, 55, 367, DateTimeKind.Utc).AddTicks(6638) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 21, 19, 28, 55, 367, DateTimeKind.Utc).AddTicks(6639), new DateTime(2023, 10, 21, 19, 28, 55, 367, DateTimeKind.Utc).AddTicks(6639) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShoeId",
                table: "ReviewsLikes");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 21, 17, 5, 24, 93, DateTimeKind.Utc).AddTicks(1048), new DateTime(2023, 10, 21, 17, 5, 24, 93, DateTimeKind.Utc).AddTicks(1050) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 21, 17, 5, 24, 93, DateTimeKind.Utc).AddTicks(1051), new DateTime(2023, 10, 21, 17, 5, 24, 93, DateTimeKind.Utc).AddTicks(1052) });
        }
    }
}
