using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDiscountEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ShoeId = table.Column<int>(type: "integer", nullable: false),
                    PriceBeforeDiscount = table.Column<float>(type: "real", nullable: false),
                    CurrentPrice = table.Column<float>(type: "real", nullable: false),
                    DiscountEndDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 11, 13, 19, 27, 45, 614, DateTimeKind.Utc).AddTicks(6454), new DateTime(2023, 11, 13, 19, 27, 45, 614, DateTimeKind.Utc).AddTicks(6459) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created", "LastModified" },
                values: new object[] { new DateTime(2023, 11, 13, 19, 27, 45, 614, DateTimeKind.Utc).AddTicks(6461), new DateTime(2023, 11, 13, 19, 27, 45, 614, DateTimeKind.Utc).AddTicks(6461) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discounts");

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
    }
}
