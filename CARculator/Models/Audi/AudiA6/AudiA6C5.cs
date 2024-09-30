using System.Collections.Generic;

namespace CARculator.Models.AudiA6
{
    public class AudiA6C5 : AudiA6
    {
        public AudiA6C5(FuelType fuelType)
        {
            Brand = "Audi";
            Model = "A6";
            Generation = "C5";
            ProductionYear = "1997-2004";
            Mileage = 140000;
            AveragePrice = 4000m;
            Transmissions = new List<TransmissionType> { TransmissionType.Manual, TransmissionType.Automatic };
            FuelType = fuelType;

            if (fuelType == FuelType.Diesel)
            {
                Engines.AddRange(new List<Engine>
                {
                    new Engine { Type = "2.5 TDI V6 150KM", Capacity = "2400-2600", Power = 150 },
                    new Engine { Type = "2.5 TDI V6 180KM", Capacity = "2400-2600", Power = 180 },
                    new Engine { Type = "3.0 TDI V6", Capacity = "2900-3100", Power = 180 }
                });
            }
            else if (fuelType == FuelType.Petrol)
            {
                Engines.AddRange(new List<Engine>
                {
                    new Engine { Type = "2.4 V6", Capacity = "2300-2500", Power = 165 },
                    new Engine { Type = "2.8 V6", Capacity = "2700-2900", Power = 193 },
                    new Engine { Type = "4.2 V8", Capacity = "4000-4200", Power = 300 }
                });
            }
        }
    }
}
