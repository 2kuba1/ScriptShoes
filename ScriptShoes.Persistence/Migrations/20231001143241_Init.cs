using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ScriptShoes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Created", "LastModified", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 1, 14, 32, 41, 530, DateTimeKind.Utc).AddTicks(4493), new DateTime(2023, 10, 1, 14, 32, 41, 530, DateTimeKind.Utc).AddTicks(4494), "User" },
                    { 2, new DateTime(2023, 10, 1, 14, 32, 41, 530, DateTimeKind.Utc).AddTicks(4495), new DateTime(2023, 10, 1, 14, 32, 41, 530, DateTimeKind.Utc).AddTicks(4496), "Admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
