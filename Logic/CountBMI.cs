﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class CountBMI
    {
        private double _bmi;

        public double GetBMI(double wgh = 65, double hgh2 = 1.75)
        {
            _bmi = wgh / hgh2;
            return _bmi;
        }
    }
}