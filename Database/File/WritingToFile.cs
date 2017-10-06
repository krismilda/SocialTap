using Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Database.File
{
    public class WritingToFile
    {
        public void Write(RestaurantInformation glassInformation)
        {
            ReadingFromFile<RestaurantInformation> readingFromFile = new ReadingFromFile<RestaurantInformation>();
            List<RestaurantInformation> listofGlass = readingFromFile.Read();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream("D:\\data.bin", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            listofGlass.Add(glassInformation);
            binaryFormatter.Serialize(fileStream, listofGlass);
            fileStream.Flush();
            fileStream.Close();
        }
    }
}
