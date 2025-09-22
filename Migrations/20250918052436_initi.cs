using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_CORE_EMPTY_CONTROLLER.Migrations
{
    /// <inheritdoc />
    public partial class initi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                column: "AuthId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2,
                column: "AuthId",
                value: 12);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                column: "AuthId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2,
                column: "AuthId",
                value: 0);
        }
    }
}
