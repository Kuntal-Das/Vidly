using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Data.Migrations
{
    public partial class AddGenere : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "GenereId",
                table: "Movies",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "Genere",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genere", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenereId",
                table: "Movies",
                column: "GenereId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genere_GenereId",
                table: "Movies",
                column: "GenereId",
                principalTable: "Genere",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genere_GenereId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Genere");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenereId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "GenereId",
                table: "Movies");
        }
    }
}
