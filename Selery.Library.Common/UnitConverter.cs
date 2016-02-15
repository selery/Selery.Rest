using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selery.Library.Common
{
    public class UnitConverter
    {

        public static decimal MetersToCentimeters(decimal meters)
        {
            return meters * 100;
        }

        public static decimal CentimetersToMeters(decimal centimeters)
        {
            return centimeters / 100;
        }
    }
}
