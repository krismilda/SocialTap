using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialTap.Utilities
{
    class Log
    {
        public static void WriteLineToFile(string str)
        {
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\Studentas\source\repos\SocialTap\SocialTap\Data\Log.txt", true))
            {
                file.WriteLine(str);
            }
        }
    }
}
