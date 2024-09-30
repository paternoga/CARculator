using System.Collections.Generic;

namespace CARculator.Models.BMW5
{
    public class BMW5G30 : BMW5
    {
        public BMW5G30(FuelType fuelType)
        {
            Brand = "BMW";
            Model = "Seria 5";
            Generation = "G30";
            ProductionYear = "2017-2023";
            Mileage = 200000;
            AveragePrice = 12000m;
            Transmissions = new List<TransmissionType> { TransmissionType.Automatic };
            FuelType = fuelType;

            if (fuelType == FuelType.Diesel)
            {
                Engines.AddRange(new List<Engine>
                {
                    new Engine { Type = "2.0d", Capacity = "2000-2200", Power = 190 },
                    new Engine { Type = "3.0d", Capacity = "3000-3200", Power = 265 },
                    new Engine { Type = "3.0d", Capacity = "3000-3200", Power = 320 }
                });
            }
            else if (fuelType == FuelType.Petrol)
            {
                Engines.AddRange(new List<Engine>
                {
                    new Engine { Type = "2.0", Capacity = "2000-2200", Power = 252 },
                    new Engine { Type = "3.0", Capacity = "3000-3200", Power = 340 },
                    new Engine { Type = "4.4 V8", Capacity = "4400-4600", Power = 600 }
                });
            }
        }
    }
}
