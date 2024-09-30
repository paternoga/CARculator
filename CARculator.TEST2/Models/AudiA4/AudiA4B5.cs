using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARculator.TEST2.Models.AudiA4
{
    public class AudiA4B5 : AudiA4
    {
        public AudiA4B5()
        {
            Brand = "Audi";
            Model = "A4 B5";
            ProductionYear = 1994;
            FuelType = "Petrol";
            TransmissionType = "Manual";
            Mileage = 100000;
            AveragePrice = 3000m;

            Engines.AddRange(new List<Engine>
            {
            new Engine { Type = "1.6 8V", Capacity = 1.6, Power = 101 },
            new Engine { Type = "1.8 Turbo", Capacity = 1.8, Power = 150 },
            new Engine { Type = "2.8 V6", Capacity = 2.8, Power = 193 }
            });
        }
    }
}
