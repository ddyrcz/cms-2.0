using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Cars.Infrastructure.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AcExpiry", "LiftUdtExpiry", "Name", "OcExpiry", "RegistrationNumber", "TachoLegalizationExpiry", "TermTechnicalResearch", "VinNumber" },
                values: new object[] { new Guid("c51ba791-541f-47ec-99b8-eec4c854d183"), null, null, "Ford Fusion", new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "SLU 55NL", null, new DateTime(2019, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AcExpiry", "LiftUdtExpiry", "Name", "OcExpiry", "RegistrationNumber", "TachoLegalizationExpiry", "TermTechnicalResearch", "VinNumber" },
                values: new object[] { new Guid("6536244a-d130-49e4-b726-e07117b5c41b"), new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ford C-MAX", new DateTime(2019, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SLU PO66", null, new DateTime(2019, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AcExpiry", "LiftUdtExpiry", "Name", "OcExpiry", "RegistrationNumber", "TachoLegalizationExpiry", "TermTechnicalResearch", "VinNumber" },
                values: new object[] { new Guid("bdf51ce4-3402-4f4d-990e-4b08e5495068"), new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Renault", new DateTime(2019, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "SLU TY5X", new DateTime(2019, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "1G1BU51H2HX113345" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("6536244a-d130-49e4-b726-e07117b5c41b"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("bdf51ce4-3402-4f4d-990e-4b08e5495068"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("c51ba791-541f-47ec-99b8-eec4c854d183"));
        }
    }
}
