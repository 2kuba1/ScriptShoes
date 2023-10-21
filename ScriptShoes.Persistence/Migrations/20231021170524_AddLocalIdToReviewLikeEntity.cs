using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddLocalIdToReviewLikeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ReviewsLikes",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "ReviewsLikes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "ReviewsLikes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LocalId",
                table: "ReviewsLikes",
                type: "text",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "ReviewsLikes");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "ReviewsLikes");

            migrationBuilder.DropColumn(
                name: "LocalId",
                table: "ReviewsLikes");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ReviewsLikes",
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
                values: new object[] { new DateTime(2023, 10, 21, 16, 58, 32, 168, DateTimeKind.Utc).AddTicks(758), new DateTime(2023, 10, 21, 16, 58, 32, 168, DateTimeKind.Utc).AddTicks(761) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 10, 21, 16, 58, 32, 168, DateTimeKind.Utc).AddTicks(762), new DateTime(2023, 10, 21, 16, 58, 32, 168, DateTimeKind.Utc).AddTicks(762) });
        }
    }
}
