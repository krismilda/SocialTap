using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ImageAnalysis
{
    public class ValueBellowZeroException : Exception
    { 
        public ValueBellowZeroException() { }

        public ValueBellowZeroException(string message) : base(message) { }

        public ValueBellowZeroException(string message, Exception innerException)
        : base(message, innerException) { }
    }
}
