using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARculator.TEST2.Models.AudiA4
{
    public class AudiA4B6 : AudiA4
    {
        public AudiA4B6()
        {
            Brand = "Audi";
            Model = "A4 B6";
            ProductionYear = 2001;
            FuelType = "Petrol";
            TransmissionType = "Manual";
            Mileage = 120000;
            AveragePrice = 5000m;

            Engines.AddRange(new List<Engine>
            {
            new Engine { Type = "1.8 T", Capacity = 1.8, Power = 150 },
            new Engine { Type = "2.0 FSI", Capacity = 2.0, Power = 130 },
            new Engine { Type = "3.0 V6", Capacity = 3.0, Power = 220 }
            });
        }
    }
}
