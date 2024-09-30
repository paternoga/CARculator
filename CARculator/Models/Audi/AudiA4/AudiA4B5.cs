using System.Collections.Generic;

namespace CARculator.Models.AudiA4
{
    public class AudiA4B5 : AudiA4
    {
        public AudiA4B5(FuelType fuelType)
        {
            Brand = "Audi";
            Model = "A4";
            Generation = "B5";
            ProductionYear = "1995-2001";
            Mileage = 100000;
            AveragePrice = 3000m;
            Transmissions = new List<TransmissionType> { TransmissionType.Manual, TransmissionType.Automatic };
            FuelType = fuelType;

            if (fuelType == FuelType.Diesel)
            {
                Engines.AddRange(new List<Engine>
            {
                new Engine { Type = "1.9 TDI", Capacity = "1800-2000", Power = 90 },
                new Engine { Type = "1.9 TDI", Capacity = "1800-2000", Power = 110 },
                new Engine { Type = "2.5 TDI V6", Capacity = "2400-2600", Power = 150 }
            });
            }
            else if (fuelType == FuelType.Petrol)
            {
                Engines.AddRange(new List<Engine>
            {
                new Engine { Type = "1.6 8V", Capacity = "1500-1700", Power = 101 },
                new Engine { Type = "1.8 Turbo", Capacity = "1701-1900", Power = 150 },
                new Engine { Type = "2.8 V6", Capacity = "2700-2900", Power = 193 }
            });
            }
        }

    }
}
