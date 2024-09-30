using System.Collections.Generic;

namespace CARculator.Models.AudiA4
{
    public class AudiA4B6 : AudiA4
    {
        public AudiA4B6(FuelType fuelType)
        {
            Brand = "Audi";
            Model = "A4";
            Generation = "B6";
            ProductionYear = "2000-2004";
            Mileage = 120000;
            AveragePrice = 5000m;
            Transmissions = new List<TransmissionType> { TransmissionType.Manual, TransmissionType.Automatic };
            FuelType = fuelType;

            if (fuelType == FuelType.Diesel)
            {
                Engines.AddRange(new List<Engine>
                {
                    new Engine { Type = "1.9 TDI", Capacity = "1800-1969", Power = 101 },
                    new Engine { Type = "2.0 TDI", Capacity = "1970-2100", Power = 140 },
                    new Engine { Type = "2.5 TDI V6", Capacity = "2400-2600", Power = 180 }
                });
            }
            else if (fuelType == FuelType.Petrol)
            {
                Engines.AddRange(new List<Engine>
                {
                    new Engine { Type = "1.6", Capacity = "1500-1700", Power = 102 },
                    new Engine { Type = "1.8 Turbo", Capacity = "1701-1900", Power = 150 },
                    new Engine { Type = "3.0 V6", Capacity = "2900-3100", Power = 220 }
                });
            }
        }
    }
}
