using System.Collections.Generic;

namespace CARculator.Models.AudiA6
{
    public class AudiA6C7 : AudiA6
    {
        public AudiA6C7(FuelType fuelType)
        {
            Brand = "Audi";
            Model = "A6";
            Generation = "C7";
            ProductionYear = "2011-2018";
            Mileage = 180000;
            AveragePrice = 9000m;
            Transmissions = new List<TransmissionType> { TransmissionType.Manual, TransmissionType.Automatic };
            FuelType = fuelType;

            if (fuelType == FuelType.Diesel)
            {
                Engines.AddRange(new List<Engine>
                {
                    new Engine { Type = "2.0 TDI", Capacity = "1900-2100", Power = 177 },
                    new Engine { Type = "3.0 TDI V6 204KM", Capacity = "2900-3100", Power = 204 },
                    new Engine { Type = "3.0 TDI V6 333KM", Capacity = "2900-3100", Power = 333 }
                });
            }
            else if (fuelType == FuelType.Petrol)
            {
                Engines.AddRange(new List<Engine>
                {
                    new Engine { Type = "2.0 TFSI", Capacity = "1900-2100", Power = 211 },
                    new Engine { Type = "3.0 TFSI V6", Capacity = "2900-3100", Power = 333 },
                    new Engine { Type = "4.0 TFSI V8", Capacity = "3900-4200", Power = 420 }
                });
            }
        }
    }
}
