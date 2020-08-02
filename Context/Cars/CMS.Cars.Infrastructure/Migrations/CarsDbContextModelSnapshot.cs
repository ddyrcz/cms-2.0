﻿// <auto-generated />
using System;
using CMS.Cars.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CMS.Cars.Infrastructure.Migrations
{
    [DbContext(typeof(CarsDbContext))]
    partial class CarsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CMS.Cars.Domain.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AcExpiry")
                        .HasColumnType("date");

                    b.Property<DateTime?>("LiftUdtExpiry")
                        .HasColumnType("date");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("OcExpiry")
                        .HasColumnType("date");

                    b.Property<DateTime?>("OcInstallmentDate");

                    b.Property<string>("RegistrationNumber");

                    b.Property<DateTime?>("TachoLegalizationExpiry")
                        .HasColumnType("date");

                    b.Property<DateTime?>("TermTechnicalResearch")
                        .HasColumnType("date");

                    b.Property<string>("VinNumber");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c51ba791-541f-47ec-99b8-eec4c854d183"),
                            Name = "Ford Fusion",
                            OcExpiry = new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RegistrationNumber = "SLU 55NL",
                            TermTechnicalResearch = new DateTime(2019, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("6536244a-d130-49e4-b726-e07117b5c41b"),
                            AcExpiry = new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Ford C-MAX",
                            OcExpiry = new DateTime(2019, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RegistrationNumber = "SLU PO66",
                            TermTechnicalResearch = new DateTime(2019, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("bdf51ce4-3402-4f4d-990e-4b08e5495068"),
                            AcExpiry = new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LiftUdtExpiry = new DateTime(2019, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Renault",
                            OcExpiry = new DateTime(2019, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RegistrationNumber = "SLU TY5X",
                            TachoLegalizationExpiry = new DateTime(2019, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TermTechnicalResearch = new DateTime(2019, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VinNumber = "1G1BU51H2HX113345"
                        },
                        new
                        {
                            Id = new Guid("40f5ea9b-ed59-4715-a87a-b78baf093cd2"),
                            AcExpiry = new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LiftUdtExpiry = new DateTime(2020, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Renault",
                            OcExpiry = new DateTime(2019, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RegistrationNumber = "SLU DU02",
                            TachoLegalizationExpiry = new DateTime(2020, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TermTechnicalResearch = new DateTime(2019, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VinNumber = "WEFOEWKFWOI0932023"
                        },
                        new
                        {
                            Id = new Guid("6e7ad885-3374-43f5-b742-1eab917e063f"),
                            AcExpiry = new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LiftUdtExpiry = new DateTime(2020, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Iveco",
                            OcExpiry = new DateTime(2019, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RegistrationNumber = "SLU 1D6P",
                            TachoLegalizationExpiry = new DateTime(2020, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TermTechnicalResearch = new DateTime(2019, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VinNumber = "OIDMCIERUOVLOWEP"
                        },
                        new
                        {
                            Id = new Guid("124b7b2a-8891-4500-a4fd-51b721df1588"),
                            AcExpiry = new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LiftUdtExpiry = new DateTime(2020, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "MAN",
                            OcExpiry = new DateTime(2019, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RegistrationNumber = "SLU 4FO0",
                            TachoLegalizationExpiry = new DateTime(2020, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TermTechnicalResearch = new DateTime(2019, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            VinNumber = "PWOREMIUVMOCODICS"
                        },
                        new
                        {
                            Id = new Guid("631d4825-ba45-45e7-ae93-c7b857ea50e1"),
                            AcExpiry = new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Renault Kangoo",
                            OcExpiry = new DateTime(2019, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RegistrationNumber = "SLU JG05",
                            TermTechnicalResearch = new DateTime(2019, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
