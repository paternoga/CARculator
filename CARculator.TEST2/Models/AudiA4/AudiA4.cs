using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARculator.TEST2.Models.AudiA4
{
    public class AudiA4 : Audi
    {
        public List<Engine> Engines { get; set; } = new List<Engine>();
    }
}
