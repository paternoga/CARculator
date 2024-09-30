using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARculator.TEST2.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Generation { get; set; }
        public int ProductionYear { get; set; }
        public string FuelType { get; set; }
        public double EngineCapacity { get; set; }
        public string TransmissionType { get; set; }
        public int Mileage { get; set; }
        public decimal AveragePrice { get; set; }
    }
}
