using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class oneToOneRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Book_Id",
                table: "bookDatials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_bookDatials_Book_Id",
                table: "bookDatials",
                column: "Book_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_bookDatials_books_Book_Id",
                table: "bookDatials",
                column: "Book_Id",
                principalTable: "books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookDatials_books_Book_Id",
                table: "bookDatials");

            migrationBuilder.DropIndex(
                name: "IX_bookDatials_Book_Id",
                table: "bookDatials");

            migrationBuilder.DropColumn(
                name: "Book_Id",
                table: "bookDatials");
        }
    }
}
