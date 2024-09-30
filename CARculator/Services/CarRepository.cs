using System.Collections.Generic;
using CARculator.Models.AudiA4; 
using CARculator.Models.BMW3;
using CARculator.Models.BMW5;
using CARculator.Models.AudiA6;
using CARculator.Models;
using CARculator.Models.MercedesCClass;
using CARculator.Models.MercedesEClass;

public class CarRepository
{
    public List<Car> Cars { get; private set; }

    public CarRepository()
    {
        Cars = new List<Car>
        {
            new AudiA4B5(FuelType.Petrol),
            new AudiA4B5(FuelType.Diesel),
            new AudiA4B6(FuelType.Petrol),
            new AudiA4B6(FuelType.Diesel),
            new AudiA4B7(FuelType.Petrol),
            new AudiA4B7(FuelType.Diesel),
            new BMW3E46(FuelType.Petrol),
            new BMW3E46(FuelType.Diesel),
            new BMW3E90(FuelType.Petrol),
            new BMW3E90(FuelType.Diesel),
            new BMW5E60(FuelType.Petrol),
            new BMW5E60(FuelType.Diesel),
            new BMW5F10(FuelType.Petrol),
            new BMW5F10(FuelType.Diesel),
            new BMW5G30(FuelType.Petrol),
            new BMW5G30(FuelType.Diesel),
            new AudiA6C5(FuelType.Petrol),
            new AudiA6C5(FuelType.Diesel),
            new AudiA6C6(FuelType.Petrol),
            new AudiA6C6(FuelType.Diesel),
            new AudiA6C7(FuelType.Petrol),
            new AudiA6C7(FuelType.Diesel),
            new MercedesCClassW204(FuelType.Petrol),
            new MercedesCClassW204(FuelType.Diesel),
            new MercedesEClassW212(FuelType.Petrol),
            new MercedesEClassW212(FuelType.Diesel),
            new MercedesEClassW213(FuelType.Petrol),
            new MercedesEClassW213(FuelType.Diesel),
        };
    }
}
