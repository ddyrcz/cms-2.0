using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Cars.Infrastructure.Migrations
{
    public partial class Change_Oc_Column_Type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OcExpiry",
                table: "Cars",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OcExpiry",
                table: "Cars",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
