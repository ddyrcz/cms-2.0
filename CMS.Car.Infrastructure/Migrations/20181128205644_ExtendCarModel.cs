using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Cars.Infrastructure.Migrations
{
    public partial class ExtendCarModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AcExpiry",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LiftUdtExpiry",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "OcExpiry",
                table: "Cars",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TachoLegalizationExpiry",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TermTechnicalResearch",
                table: "Cars",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "VinNumber",
                table: "Cars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcExpiry",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "LiftUdtExpiry",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "OcExpiry",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "TachoLegalizationExpiry",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "TermTechnicalResearch",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "VinNumber",
                table: "Cars");
        }
    }
}
