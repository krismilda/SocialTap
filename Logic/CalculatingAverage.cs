using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CalculatingAverage
    {
        public static double GetAverage(int number1, int number2)
        {
            float average= number1 / number2;
            return Math.Round(average, 2);
        }
    }
}