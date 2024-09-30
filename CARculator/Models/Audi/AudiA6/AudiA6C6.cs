using System.Collections.Generic;

namespace CARculator.Models.AudiA6
{
    public class AudiA6C6 : AudiA6
    {
        public AudiA6C6(FuelType fuelType)
        {
            Brand = "Audi";
            Model = "A6";
            Generation = "C6";
            ProductionYear = "2004-2011";
            Mileage = 160000;
            AveragePrice = 6000m;
            Transmissions = new List<TransmissionType> { TransmissionType.Manual, TransmissionType.Automatic };
            FuelType = fuelType;

            if (fuelType == FuelType.Diesel)
            {
                Engines.AddRange(new List<Engine>
                {
                    new Engine { Type = "2.0 TDI", Capacity = "1900-2100", Power = 140 },
                    new Engine { Type = "2.7 TDI V6", Capacity = "2600-2800", Power = 180 },
                    new Engine { Type = "3.0 TDI V6", Capacity = "2900-3100", Power = 233 }
                });
            }
            else if (fuelType == FuelType.Petrol)
            {
                Engines.AddRange(new List<Engine>
                {
                    new Engine { Type = "2.4 V6", Capacity = "2300-2500", Power = 170 },
                    new Engine { Type = "3.2 FSI V6", Capacity = "3100-3300", Power = 250 },
                    new Engine { Type = "4.2 FSI V8", Capacity = "4000-4200", Power = 350 }
                });
            }
        }
    }
}
