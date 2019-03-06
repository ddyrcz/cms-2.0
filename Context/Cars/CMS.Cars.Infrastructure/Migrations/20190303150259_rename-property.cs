using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Cars.Infrastructure.Migrations
{
    public partial class renameproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Cars",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Cars",
                newName: "Description");
        }
    }
}
