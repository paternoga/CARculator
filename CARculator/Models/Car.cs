using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARculator.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Generation { get; set; }
        public string ProductionYear { get; set; }
        public List<TransmissionType> Transmissions { get; set; } 
        public int Mileage { get; set; }
        public decimal AveragePrice { get; set; }

        public List<Engine> Engines { get; set; } = new List<Engine>();
        public FuelType FuelType { get; set; }
            

        //public virtual string DisplayInfo()
        //{
        //    return $"Brand: {Brand}\nModel: {Model}\nGeneration: {Generation}\n" +
        //           $"Year: {ProductionYear}\nFuel: {FuelType}\nEngine Capacity: {Engines}L\n" +
        //           $"Transmission: {Transmissions}\nMileage: {Mileage} km\nPrice: ${AveragePrice}";
        //}


    }
}
