using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARculator.Models
{
    public class BMW : Car
    {
        public bool HasXDrive { get; set; }
        public bool HasIDrive { get; set; }

        //public override string DisplayInfo()
        //{
        //    string baseInfo = base.DisplayInfo();

        //    return baseInfo + $"\nHas xDrive: {HasXDrive}\n" +
        //                      $"Has iDrive: {HasIDrive}";
        //}
    }

}
