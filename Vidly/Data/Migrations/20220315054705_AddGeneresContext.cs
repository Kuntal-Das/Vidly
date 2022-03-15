using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Data.Migrations
{
    public partial class AddGeneresContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genere_GenereId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genere",
                table: "Genere");

            migrationBuilder.RenameTable(
                name: "Genere",
                newName: "Generes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Generes",
                table: "Generes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Generes_GenereId",
                table: "Movies",
                column: "GenereId",
                principalTable: "Generes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Generes_GenereId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Generes",
                table: "Generes");

            migrationBuilder.RenameTable(
                name: "Generes",
                newName: "Genere");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genere",
                table: "Genere",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genere_GenereId",
                table: "Movies",
                column: "GenereId",
                principalTable: "Genere",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
