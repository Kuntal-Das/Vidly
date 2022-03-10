using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Data.Migrations
{
    public partial class AddMoreGeneres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.Sql("INSERT INTO GENERE (Id, Name) VALUES (1, 'Action')");
            //migrationBuilder.Sql("INSERT INTO GENERE (Id, Name) VALUES (2, 'Thriller')");
            //migrationBuilder.Sql("INSERT INTO GENERE (Id, Name) VALUES (3, 'Family')");
            //migrationBuilder.Sql("INSERT INTO GENERE (Id, Name) VALUES (4, 'Romance')");
            //migrationBuilder.Sql("INSERT INTO GENERE (Id, Name) VALUES (5, 'Comedy')");
            migrationBuilder.Sql("INSERT INTO GENERE (Id, Name) VALUES (6, 'Sci-fi')");
            migrationBuilder.Sql("INSERT INTO GENERE (Id, Name) VALUES (7, 'Adventure')");
            migrationBuilder.Sql("INSERT INTO GENERE (Id, Name) VALUES (8, 'Sci-fi/Adventure')");
            migrationBuilder.Sql("INSERT INTO GENERE (Id, Name) VALUES (9, 'Sci-fi/Thriller')");
            migrationBuilder.Sql("INSERT INTO GENERE (Id, Name) VALUES (10, 'Comedy/Romance')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
