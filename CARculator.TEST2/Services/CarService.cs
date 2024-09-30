using CARculator.TEST2.Models.AudiA4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARculator.TEST2.Services
{
    public class CarService
    {
        private List<AudiA4> audiA4Generations;

        public CarService()
        {
            LoadCars();
        }

        private void LoadCars()
        {
            audiA4Generations = new List<AudiA4>
            {
                new AudiA4B5(),
                new AudiA4B6(),
                new AudiA4B7(),
                //new AudiA4B8(),
                //new AudiA4B9()
            };
        }

        public List<AudiA4> GetAudiA4Generations()
        {
            return audiA4Generations;
        }

        public AudiA4 GetAudiA4ByModel(string model)
        {
            return audiA4Generations.Find(car => car.Model == model);
        }
    }
}
