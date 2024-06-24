using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class FluentOneToManyRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fluent_BookAuthorMap");

            migrationBuilder.AddColumn<int>(
                name: "Publisher_Id",
                table: "Fluent_books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_books_Publisher_Id",
                table: "Fluent_books",
                column: "Publisher_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_books_Fluent_publishers_Publisher_Id",
                table: "Fluent_books",
                column: "Publisher_Id",
                principalTable: "Fluent_publishers",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_books_Fluent_publishers_Publisher_Id",
                table: "Fluent_books");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_books_Publisher_Id",
                table: "Fluent_books");

            migrationBuilder.DropColumn(
                name: "Publisher_Id",
                table: "Fluent_books");

            migrationBuilder.CreateTable(
                name: "Fluent_BookAuthorMap",
                columns: table => new
                {
                    Author_Id = table.Column<int>(type: "int", nullable: false),
                    Book_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_BookAuthorMap", x => new { x.Author_Id, x.Book_Id });
                });
        }
    }
}
