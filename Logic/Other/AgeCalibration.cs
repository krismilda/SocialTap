using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{

    public static class AgeCalibration
    {
        public static int CalibrateAge(this int year)
        {
            year += 22;
            return year;
        }
    }

}
