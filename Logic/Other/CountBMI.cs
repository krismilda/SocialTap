using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class CountBMI
    {
        private double _bmi;

        public double GetBMI(double wgh = 65, double hgh = 1.75)
        {
            _bmi = ((wgh*1000) / (hgh*hgh))*10;
            return _bmi;
        }
    }
}