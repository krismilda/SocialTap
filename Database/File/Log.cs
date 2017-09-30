using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Utilities
{
    public class Log
    {
        public static void WriteLineToFile(string str)
        {
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"D:\DatLog.txt", true))
            {
                file.WriteLine(str);
            }
        }
    }
}
