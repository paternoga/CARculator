using System.Collections.Generic;

namespace CARculator.Models.BMW5
{
    public class BMW5F10 : BMW5
    {
        public BMW5F10(FuelType fuelType)
        {
            Brand = "BMW";
            Model = "Seria 5";
            Generation = "F10";
            ProductionYear = "2009-2017";
            Mileage = 150000;
            AveragePrice = 8000m;
            Transmissions = new List<TransmissionType> { TransmissionType.Manual, TransmissionType.Automatic};
            FuelType = fuelType;

            if (fuelType == FuelType.Diesel)
            {
                Engines.AddRange(new List<Engine>
                {
                    new Engine { Type = "2.0d", Capacity = "1900-2100", Power = 184 },
                    new Engine { Type = "3.0d", Capacity = "2900-3100", Power = 258 },
                    new Engine { Type = "3.0d", Capacity = "2900-3100", Power = 313 }
                });
            }
            else if (fuelType == FuelType.Petrol)
            {
                Engines.AddRange(new List<Engine>
                {
                    new Engine { Type = "2.0", Capacity = "1900-2100", Power = 184 },
                    new Engine { Type = "3.0", Capacity = "2900-3100", Power = 320 },
                    new Engine { Type = "4.4 V8", Capacity = "4300-4500", Power = 407 }
                });
            }
        }
    }
}
