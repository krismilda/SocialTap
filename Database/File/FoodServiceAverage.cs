using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.File
{
    public class FoodServiceAverage
    {
        public static string getAverageOfLiquid(GlassInformation glassInformation)
        {
            List<GlassInformationFile> listofGlass = ReadingFromFile.Read();
            foreach (GlassInformationFile glass in listofGlass)
            {
                if (glass.Name.Equals(glassInformation.Name) && glass.Address.Equals(glassInformation.Address))
                {
                    return glass.Average.ToString();
                }
            }
            return "-";
        }
    }
}
