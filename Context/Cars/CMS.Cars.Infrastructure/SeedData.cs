using CMS.Cars.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS.Cars.Infrastructure
{
    static class SeedData
    {
        public static Car[] Cars = new Car[]
        {
            new Car(new Guid("c51ba791-541f-47ec-99b8-eec4c854d183"),
                "Ford Fusion", 
                "SLU 55NL",
                null,
                new DateTime(2019, 05, 14),
                new DateTime(2019, 08, 15),
                null,
                null,
                null),
            new Car(new Guid("6536244a-d130-49e4-b726-e07117b5c41b"),
                "Ford C-MAX",
                "SLU PO66",
                null,
                new DateTime(2019, 06, 22),
                new DateTime(2019, 06, 01),
                new DateTime(2019, 09, 16),
                null,
                null),
            new Car(new Guid("bdf51ce4-3402-4f4d-990e-4b08e5495068"),
                "Renault",
                "SLU TY5X",
                "1G1BU51H2HX113345",
                new DateTime(2019, 12, 05),
                new DateTime(2019, 11, 26),
                new DateTime(2019, 09, 16),
                new DateTime(2019, 05, 12),
                new DateTime(2019, 04, 22))
        };
    }
}
