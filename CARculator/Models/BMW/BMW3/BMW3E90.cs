using System.Collections.Generic;

namespace CARculator.Models.BMW3
{
    public class BMW3E90 : BMW3
    {
        public BMW3E90(FuelType fuelType)
        {
            Brand = "BMW";
            Model = "Seria 3";
            Generation = "E90";
            ProductionYear = "2005-2012";
            Mileage = 130000;
            AveragePrice = 6000m;
            Transmissions = new List<TransmissionType> { TransmissionType.Manual, TransmissionType.Automatic };
            FuelType = fuelType;

            if (fuelType == FuelType.Diesel)
            {
                Engines.AddRange(new List<Engine>
                {
                    new Engine { Type = "2.0d", Capacity = "1900-2100", Power = 143 },
                    new Engine { Type = "3.0d", Capacity = "2900-3100", Power = 231 }
                });
            }
            else if (fuelType == FuelType.Petrol)
            {
                Engines.AddRange(new List<Engine>
                {
                    new Engine { Type = "1.6", Capacity = "1500-1700", Power = 115 },
                    new Engine { Type = "2.0", Capacity = "1900-2100", Power = 143 },
                    new Engine { Type = "3.0", Capacity = "2900-3100", Power = 306 }
                });
            }
        }
    }
}
