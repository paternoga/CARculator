using CARculator.Models.AudiA4;
using CARculator.Models;
using System.Net.Http;
using HtmlAgilityPack;
using Wpf.Ui.Controls;
using Microsoft.VisualBasic.FileIO;

public class CarService
{
    private readonly CarRepository _carRepository;
    private List<Car> _cars;
    private readonly HttpClient _client;
    private List<object> dynamicCars = new List<object>();

    public CarService()
    {
        _client = new HttpClient();
        _client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36");

        _carRepository = new CarRepository();
        _cars = _carRepository.Cars;
    }

    public List<Car> GetAllCars()
    {
        return _cars;
    }

    public void AddDynamicCar(object car)
    {
        dynamicCars.Add(car);
    }
    public List<Car> GetFilteredCars(string brand, string model, string generation,
                                      string year, double? engineCapacity, TransmissionType? transmission,
                                      int? mileage, decimal? averagePrice, FuelType? fuelType,
                                      string engineType)
    {
        var query = _cars.AsQueryable();

        if (!string.IsNullOrEmpty(brand))
            query = query.Where(c => c.Brand == brand);
        if (!string.IsNullOrEmpty(model))
            query = query.Where(c => c.Model == model);
        if (!string.IsNullOrEmpty(generation))
            query = query.Where(c => c.Generation == generation);
        if (!string.IsNullOrEmpty(year))
            query = query.Where(c => c.ProductionYear == year);
        if (transmission.HasValue)
            query = query.Where(c => c.Transmissions.Contains(transmission.Value));
        if (mileage.HasValue)
            query = query.Where(c => c.Mileage == mileage.Value);
        if (averagePrice.HasValue)
            query = query.Where(c => c.AveragePrice == averagePrice.Value);
        if (fuelType.HasValue)
            query = query.Where(c => c.FuelType == fuelType.Value);
        if (!string.IsNullOrEmpty(engineType))
            query = query.Where(c => c.Engines.Any(e => e.Type == engineType));

        return query.ToList();
    }

    public List<object> GetFilteredCarsDynamic(Type carType, List<object> carList,
                                             string brand, string model, string generation,
                                             string year, double? engineCapacity, TransmissionType? transmission,
                                             int? mileage, decimal? averagePrice, FuelType? fuelType,
                                             string engineType)
    {
        var query = carList.AsQueryable();

        var properties = carType.GetProperties();

        if (!string.IsNullOrEmpty(brand))
        {
            var brandProperty = properties.FirstOrDefault(p => p.Name == "Brand");
            if (brandProperty != null)
            {
                query = query.Where(c => (string)brandProperty.GetValue(c) == brand);
            }
        }

        if (!string.IsNullOrEmpty(model))
        {
            var modelProperty = properties.FirstOrDefault(p => p.Name == "Model");
            if (modelProperty != null)
            {
                query = query.Where(c => (string)modelProperty.GetValue(c) == model);
            }
        }

        if (!string.IsNullOrEmpty(generation))
        {
            var generationProperty = properties.FirstOrDefault(p => p.Name == "Generation");
            if (generationProperty != null)
            {
                query = query.Where(c => (string)generationProperty.GetValue(c) == generation);
            }
        }

        if (!string.IsNullOrEmpty(year))
        {
            var yearProperty = properties.FirstOrDefault(p => p.Name == "ProductionYear");
            if (yearProperty != null)
            {
                query = query.Where(c => (string)yearProperty.GetValue(c) == year);
            }
        }

        if (transmission.HasValue)
        {
            var transmissionProperty = properties.FirstOrDefault(p => p.Name == "Transmissions");
            if (transmissionProperty != null)
            {
                query = query.Where(c => ((List<TransmissionType>)transmissionProperty.GetValue(c)).Contains(transmission.Value));
            }
        }

        if (mileage.HasValue)
        {
            var mileageProperty = properties.FirstOrDefault(p => p.Name == "Mileage");
            if (mileageProperty != null)
            {
                query = query.Where(c => (int)mileageProperty.GetValue(c) == mileage.Value);
            }
        }

        if (averagePrice.HasValue)
        {
            var averagePriceProperty = properties.FirstOrDefault(p => p.Name == "AveragePrice");
            if (averagePriceProperty != null)
            {
                query = query.Where(c => (decimal)averagePriceProperty.GetValue(c) == averagePrice.Value);
            }
        }

        if (fuelType.HasValue)
        {
            var fuelTypeProperty = properties.FirstOrDefault(p => p.Name == "FuelType");
            if (fuelTypeProperty != null)
            {
                query = query.Where(c => (FuelType)fuelTypeProperty.GetValue(c) == fuelType.Value);
            }
        }

        if (!string.IsNullOrEmpty(engineType))
        {
            var enginesProperty = properties.FirstOrDefault(p => p.Name == "Engines");
            if (enginesProperty != null)
            {
                query = query.Where(c => ((List<Engine>)enginesProperty.GetValue(c)).Any(e => e.Type == engineType));
            }
        }

        return query.ToList();
    }



}
