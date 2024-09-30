using CARculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CARculator.Services
{
    public static class CarModelHelper
    {
        public static string GetProductionYears(List<Car> cars, string brand, string model, string generation, FuelType fuelType)
        {
            var relevantCars = cars.Where(c => c.Brand == brand && c.Model == model && c.Generation == generation && c.FuelType == fuelType).ToList();

            if (!relevantCars.Any())
            {
                return "Unknown";
            }

            var productionYears = relevantCars.Select(c => int.Parse(c.ProductionYear)).ToList();

            var minYear = productionYears.Min();
            var maxYear = productionYears.Max();

            if (minYear == maxYear)
            {
                return minYear.ToString();
            }
            else
            {
                return $"{minYear}-{maxYear}";
            }
        }




        public static List<Engine> GetEnginesForModel(string brand, string model, string generation, FuelType fuelType)
        {
            var carTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Car)) && !t.IsAbstract)
                .ToList();

            foreach (var type in carTypes)
            {
                var constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public);
                foreach (var constructor in constructors)
                {
                    var parameters = constructor.GetParameters();
                    if (parameters.Length == 1 && parameters[0].ParameterType == typeof(FuelType))
                    {
                        var instance = (Car)Activator.CreateInstance(type, fuelType);
                        if (instance.Brand == brand && instance.Model == model && instance.Generation == generation)
                        {
                            return instance.Engines;
                        }
                    }
                }
            }

            return new List<Engine>(); 
        }

    }
}
