using System.Collections.Generic;

namespace CARculator.Models.MercedesEClass
{
    public class MercedesEClassW213 : MercedesEClass
    {
        public MercedesEClassW213(FuelType fuelType)
        {
            Brand = "Mercedes-Benz";
            Model = "Klasa E";
            Generation = "W213";
            ProductionYear = "2016-2023";
            Mileage = 200000;
            AveragePrice = 12000m;
            Transmissions = new List<TransmissionType> { TransmissionType.Automatic };
            FuelType = fuelType;

            if (fuelType == FuelType.Diesel)
            {
                Engines.AddRange(new List<Engine>
                {
                    new Engine { Type = "2.0 CDI", Capacity = "1900-2100", Power = 194 },
                    new Engine { Type = "3.0 CDI 258 KM", Capacity = "2900-3100", Power = 258 },
                    new Engine { Type = "3.0 CDI 330 KM", Capacity = "2900-3100", Power = 330 }
                });
            }
            else if (fuelType == FuelType.Petrol)
            {
                Engines.AddRange(new List<Engine>
                {
                    new Engine { Type = "2.0", Capacity = "1900-2100", Power = 241 },
                    new Engine { Type = "3.0", Capacity = "2900-3100", Power = 362 },
                    new Engine { Type = "4.0 V8", Capacity = "4000-4200", Power = 603 }
                });
            }
        }
    }
}