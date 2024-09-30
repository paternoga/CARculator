using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARculator.TEST2.Models.AudiA4
{
    public class AudiA4B7 : AudiA4
    {
        public AudiA4B7()
        {
            Brand = "Audi";
            Model = "A4 B7";
            ProductionYear = 2005;
            FuelType = "Petrol";
            TransmissionType = "Manual";
            Mileage = 80000;
            AveragePrice = 7000m;

            Engines.AddRange(new List<Engine>
            {
            new Engine { Type = "1.8 T", Capacity = 1.8, Power = 160 },
            new Engine { Type = "2.0 TFSI", Capacity = 2.0, Power = 200 },
            new Engine { Type = "3.2 V6", Capacity = 3.2, Power = 255 }
            });
        }
    }
}
