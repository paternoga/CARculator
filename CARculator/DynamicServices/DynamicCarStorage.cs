using System;
using System.Collections.Generic;

namespace CARculator.DynamicServices
{
    public class DynamicCarStorage
    {
        private static DynamicCarStorage _instance;
        private readonly List<object> _cars;  // Przechowujemy instancje samochodów
        private readonly List<Type> _carTypes;  // Przechowujemy typy dynamiczne

        private DynamicCarStorage()
        {
            _cars = new List<object>();
            _carTypes = new List<Type>();
        }

        public static DynamicCarStorage Instance => _instance ?? (_instance = new DynamicCarStorage());

        public void AddCar(object car)
        {
            _cars.Add(car);
        }

        public List<object> GetCars()
        {
            return _cars;
        }

        public void AddCarType(Type carType)
        {
            _carTypes.Add(carType);
        }

        public List<Type> GetCarTypes()
        {
            return _carTypes;
        }

        public Type GetCarType(string className)
        {
            return _carTypes.Find(t => t.Name == className);
        }
    }
}
