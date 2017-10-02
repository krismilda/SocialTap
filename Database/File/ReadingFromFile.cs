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
    public class ReadingFromFile
    {


        public static List<GlassInformationFile> Read()
        {
            List<GlassInformationFile> glassInformation = new List<GlassInformationFile>();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream("D:\\data.bin", FileMode.Open, FileAccess.Read, FileShare.None);
            glassInformation = (List<GlassInformationFile>)binaryFormatter.Deserialize(fileStream);
            fileStream.Flush();
            fileStream.Close();
            return glassInformation;
        }
    }
}

