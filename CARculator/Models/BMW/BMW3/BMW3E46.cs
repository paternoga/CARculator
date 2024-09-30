using System.Collections.Generic;

namespace CARculator.Models.BMW3
{
    public class BMW3E46 : BMW3
    {
        public BMW3E46(FuelType fuelType)
        {
            Brand = "BMW";
            Model = "Seria 3";
            Generation = "E46";
            ProductionYear = "1998-2007";
            Mileage = 120000;
            AveragePrice = 4000m;
            Transmissions = new List<TransmissionType> { TransmissionType.Manual, TransmissionType.Automatic };
            FuelType = fuelType;

            if (fuelType == FuelType.Diesel)
            {
                Engines.AddRange(new List<Engine>
                {
                    new Engine { Type = "2.0d", Capacity = "1900-2100", Power = 115 },
                    new Engine { Type = "2.0d", Capacity = "1900-2100", Power = 150 },
                    new Engine { Type = "3.0d", Capacity = "3000-3200", Power = 204 }
                });
            }
            else if (fuelType == FuelType.Petrol)
            {
                Engines.AddRange(new List<Engine>
                {
                    new Engine { Type = "1.6", Capacity = "1500-1700", Power = 105 },
                    new Engine { Type = "2.0", Capacity = "1900-2100", Power = 143 },
                    new Engine { Type = "3.0", Capacity = "2900-3100", Power = 231 }
                });
            }
        }
    }
}
