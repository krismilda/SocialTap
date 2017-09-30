using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    class CoordinatesConverter
    {
        public static String GetConvertedCoordinates(Double latitude, double longitude)
        {
            NumberFormatInfo nnumberFormat = new NumberFormatInfo();
            nnumberFormat.NumberDecimalSeparator = ".";
            return latitude.ToString(nnumberFormat) + "," + longitude.ToString(nnumberFormat);
        }
    }
}
