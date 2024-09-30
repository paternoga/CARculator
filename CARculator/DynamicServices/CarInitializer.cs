using CARculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARculator.DynamicServices
{
    public class CarInitializer
    {
        public static object CreateAndInitializeCar(Type carType)
        {
            var carInstance = Activator.CreateInstance(carType);

            // Set properties using reflection
            var properties = carType.GetProperties();
            foreach (var prop in properties)
            {
                if (prop.Name == "Brand") prop.SetValue(carInstance, "Audi");
                if (prop.Name == "Model") prop.SetValue(carInstance, "A4");
                if (prop.Name == "Generation") prop.SetValue(carInstance, "B9");
                if (prop.Name == "ProductionYear") prop.SetValue(carInstance, "2015-2024");
                if (prop.Name == "Mileage") prop.SetValue(carInstance, 100000);
                if (prop.Name == "AveragePrice") prop.SetValue(carInstance, 300000m);
                if (prop.Name == "FuelType") prop.SetValue(carInstance, FuelType.Petrol);

                if (prop.Name == "Transmissions")
                {
                    prop.SetValue(carInstance, new List<TransmissionType> { TransmissionType.Manual, TransmissionType.Automatic });
                }

                if (prop.Name == "Engines")
                {
                    var engines = new List<Engine>
                {
                    new Engine { Type = "1.6 8V", Capacity = "1500-1700", Power = 201 },
                    new Engine { Type = "1.8 Turbo", Capacity = "1701-1900", Power = 220 },
                    new Engine { Type = "2.8 V6", Capacity = "2700-2900", Power = 293 }
                };
                    prop.SetValue(carInstance, engines);
                }
            }

            return carInstance;
        }
    }
}
