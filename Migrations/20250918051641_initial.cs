using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_CORE_EMPTY_CONTROLLER.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "11, 1"),
                    AuthName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PublicationYear = table.Column<DateOnly>(type: "date", nullable: false),
                    AuthId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthId",
                        column: x => x.AuthId,
                        principalTable: "Authors",
                        principalColumn: "AuthId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthId", "AuthName" },
                values: new object[,]
                {
                    { 11, "Robert Baratheon" },
                    { 12, "Jon Stark" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthId", "Price", "PublicationYear", "Title" },
                values: new object[,]
                {
                    { 1, 11, 4500m, new DateOnly(2002, 1, 15), "Winterfell" },
                    { 2, 12, 5000m, new DateOnly(2005, 11, 23), "Vale" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthId",
                table: "Books",
                column: "AuthId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
