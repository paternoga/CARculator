using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARculator.Models
{
    public class Audi : Car
    {
        public bool HasQuattroSystem { get; set; }
        public bool HasVirtualCockpit { get; set; }
        //public override string DisplayInfo()
        //{
        //    string baseInfo = base.DisplayInfo();
    
        //    return baseInfo + $"\nHas Quattro System: {HasQuattroSystem}\n" +
        //                      $"Has Virtual Cockpit: {HasVirtualCockpit}";
        //}

    }
}
