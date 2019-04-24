using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Cars.Infrastructure.Migrations
{
    public partial class moreseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "AcExpiry", "LiftUdtExpiry", "Name", "OcExpiry", "RegistrationNumber", "TachoLegalizationExpiry", "TermTechnicalResearch", "VinNumber" },
                values: new object[,]
                {
                    { new Guid("40f5ea9b-ed59-4715-a87a-b78baf093cd2"), new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Renault", new DateTime(2019, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "SLU DU02", new DateTime(2020, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "WEFOEWKFWOI0932023" },
                    { new Guid("6e7ad885-3374-43f5-b742-1eab917e063f"), new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iveco", new DateTime(2019, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "SLU 1D6P", new DateTime(2020, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "OIDMCIERUOVLOWEP" },
                    { new Guid("124b7b2a-8891-4500-a4fd-51b721df1588"), new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "MAN", new DateTime(2019, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "SLU 4FO0", new DateTime(2020, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "PWOREMIUVMOCODICS" },
                    { new Guid("631d4825-ba45-45e7-ae93-c7b857ea50e1"), new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Renault Kangoo", new DateTime(2019, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "SLU JG05", null, new DateTime(2019, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("124b7b2a-8891-4500-a4fd-51b721df1588"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("40f5ea9b-ed59-4715-a87a-b78baf093cd2"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("631d4825-ba45-45e7-ae93-c7b857ea50e1"));

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: new Guid("6e7ad885-3374-43f5-b742-1eab917e063f"));
        }
    }
}
