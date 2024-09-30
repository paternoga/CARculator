using System.Collections.Generic;

namespace CARculator.Models.BMW5
{
    public class BMW5E60 : BMW5
    {
        public BMW5E60(FuelType fuelType)
        {
            Brand = "BMW";
            Model = "Seria 5";
            Generation = "E60";
            ProductionYear = "2003-2010";
            Mileage = 150000;
            AveragePrice = 7000m;
            Transmissions = new List<TransmissionType> { TransmissionType.Manual, TransmissionType.Automatic };
            FuelType = fuelType;

            if (fuelType == FuelType.Diesel)
            {
                Engines.AddRange(new List<Engine>
                {
                    new Engine { Type = "2.0d", Capacity = "1900-2100", Power = 143 },
                    new Engine { Type = "2.5d", Capacity = "2400-2600", Power = 177 },
                    new Engine { Type = "3.0d", Capacity = "2900-3100", Power = 235 }
                });
            }
            else if (fuelType == FuelType.Petrol)
            {
                Engines.AddRange(new List<Engine>
                {
                    new Engine { Type = "2.0", Capacity = "1900-2100", Power = 156 },
                    new Engine { Type = "3.0", Capacity = "2900-3100", Power = 258 },
                    new Engine { Type = "4.0 V8", Capacity = "3900-4100", Power = 360 }
                });
            }
        }
    }
}
