using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class FluentOneToOneRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fluent_BookAuthorMap",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Author_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_BookAuthorMap", x => new { x.Author_Id, x.Book_Id });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_bookDatials_Book_Id",
                table: "Fluent_bookDatials",
                column: "Book_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_bookDatials_Fluent_books_Book_Id",
                table: "Fluent_bookDatials",
                column: "Book_Id",
                principalTable: "Fluent_books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_bookDatials_Fluent_books_Book_Id",
                table: "Fluent_bookDatials");

            migrationBuilder.DropTable(
                name: "Fluent_BookAuthorMap");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_bookDatials_Book_Id",
                table: "Fluent_bookDatials");
        }
    }
}
