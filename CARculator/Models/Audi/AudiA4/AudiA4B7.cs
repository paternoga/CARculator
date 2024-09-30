using System.Collections.Generic;

namespace CARculator.Models.AudiA4
{
    public class AudiA4B7 : AudiA4
    {
        public AudiA4B7(FuelType fuelType)
        {
            Brand = "Audi";
            Model = "A4";
            Generation = "B7";
            ProductionYear = "2004-2007";
            Mileage = 130000;
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
                    new Engine { Type = "2.0 FSI", Capacity = "1900-2100", Power = 150 },
                    new Engine { Type = "2.0 TFSI", Capacity = "1900-2100", Power = 200 },
                    new Engine { Type = "3.2 V6", Capacity = "3100-3300", Power = 250 }
                });
            }
        }
    }
}
