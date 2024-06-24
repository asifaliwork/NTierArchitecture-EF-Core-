using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class oneToManyRealtionBetweenBook_Publisher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Publisher_Id",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "BookId",
                keyValue: 1,
                column: "Publisher_Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "BookId",
                keyValue: 2,
                column: "Publisher_Id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "BookId",
                keyValue: 3,
                column: "Publisher_Id",
                value: 3);

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "BookId",
                keyValue: 4,
                column: "Publisher_Id",
                value: 2);

            migrationBuilder.InsertData(
                table: "publishers",
                columns: new[] { "Publisher_Id", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Pehsawar", "Asif" },
                    { 2, "Mardan", "Asif Ali" },
                    { 3, "Katlang", "Asif Khan" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_Publisher_Id",
                table: "books",
                column: "Publisher_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_books_publishers_Publisher_Id",
                table: "books",
                column: "Publisher_Id",
                principalTable: "publishers",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_publishers_Publisher_Id",
                table: "books");

            migrationBuilder.DropIndex(
                name: "IX_books_Publisher_Id",
                table: "books");

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "Publisher_Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "Publisher_Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "Publisher_Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Publisher_Id",
                table: "books");
        }
    }
}
