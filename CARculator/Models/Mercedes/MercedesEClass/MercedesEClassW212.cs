using System.Collections.Generic;

namespace CARculator.Models.MercedesEClass
{
    public class MercedesEClassW212 : MercedesEClass
    {
        public MercedesEClassW212(FuelType fuelType)
        {
            Brand = "Mercedes-Benz";
            Model = "Klasa E";
            Generation = "W212";
            ProductionYear = "2009-2016";
            Mileage = 160000;
            AveragePrice = 7000m;
            Transmissions = new List<TransmissionType> { TransmissionType.Manual, TransmissionType.Automatic };
            FuelType = fuelType;

            if (fuelType == FuelType.Diesel)
            {
                Engines.AddRange(new List<Engine>
                {
                    new Engine { Type = "2.1 CDI", Capacity = "2100-2300", Power = 136 },
                    new Engine { Type = "2.2 CDI", Capacity = "2200-2400", Power = 170 },
                    new Engine { Type = "3.0 CDI", Capacity = "2900-3100", Power = 231 }
                });
            }
            else if (fuelType == FuelType.Petrol)
            {
                Engines.AddRange(new List<Engine>
                {
                    new Engine { Type = "1.8", Capacity = "1500-1700", Power = 184 },
                    new Engine { Type = "3.0 V6", Capacity = "2900-3100", Power = 231 },
                    new Engine { Type = "5.5 V8", Capacity = "5400-5600", Power = 518 }
                });
            }
        }
    }
}
