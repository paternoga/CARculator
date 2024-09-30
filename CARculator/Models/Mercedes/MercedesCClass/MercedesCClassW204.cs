using System.Collections.Generic;

namespace CARculator.Models.MercedesCClass
{
    public class MercedesCClassW204 : MercedesCClass
    {
        public MercedesCClassW204(FuelType fuelType)
        {
            Brand = "Mercedes-Benz";
            Model = "Klasa C";
            Generation = "W204";
            ProductionYear = "2007-2014";
            Mileage = 140000;
            AveragePrice = 5000m;
            Transmissions = new List<TransmissionType> { TransmissionType.Manual, TransmissionType.Automatic };
            FuelType = fuelType;

            if (fuelType == FuelType.Diesel)
            {
                Engines.AddRange(new List<Engine>
                {
                    new Engine { Type = "2.1 CDI", Capacity = "2000-2200", Power = 136 },
                    new Engine { Type = "2.2 CDI", Capacity = "2101-2300", Power = 170 },
                    new Engine { Type = "3.0 CDI", Capacity = "3000-3200", Power = 231 }
                });
            }
            else if (fuelType == FuelType.Petrol)
            {
                Engines.AddRange(new List<Engine>
                {
                    new Engine { Type = "1.8", Capacity = "1700-1900", Power = 143 },
                    new Engine { Type = "2.0", Capacity = "1901-2100", Power = 184 },
                    new Engine { Type = "3.0 V6", Capacity = "3000-3200", Power = 228 }
                });
            }
        }
    }
}
