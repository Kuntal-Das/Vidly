using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Data.Migrations
{
    public partial class PopulateNamesInMembershipType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE MEMBERSHIPTYPE SET Name='Pay As you go' WHERE Id=1");
            migrationBuilder.Sql("UPDATE MEMBERSHIPTYPE SET Name='Monthly' WHERE Id=2");
            migrationBuilder.Sql("UPDATE MEMBERSHIPTYPE SET Name='Quaterly' WHERE Id=3");
            migrationBuilder.Sql("UPDATE MEMBERSHIPTYPE SET Name='Yearly' WHERE Id=4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
