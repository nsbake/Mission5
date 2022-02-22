using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission4.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    RatingID = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.RatingID);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    FilmID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    LentTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.FilmID);
                });

            migrationBuilder.InsertData(
                table: "Rating",
                column: "RatingID",
                value: "G");

            migrationBuilder.InsertData(
                table: "Rating",
                column: "RatingID",
                value: "PG");

            migrationBuilder.InsertData(
                table: "Rating",
                column: "RatingID",
                value: "PG-13");

            migrationBuilder.InsertData(
                table: "Rating",
                column: "RatingID",
                value: "R");

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "FilmID", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, "Action", "James Mangold", false, null, null, "PG-13", "Ford vs Ferarri", 2019 });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "FilmID", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, "History", "Gavin O'Connor", false, null, null, "PG", "Miracle", 2004 });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "FilmID", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, "Action", "Christopher Nolan", false, null, null, "PG-13", "The Dark Knight", 2008 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "Responses");
        }
    }
}
