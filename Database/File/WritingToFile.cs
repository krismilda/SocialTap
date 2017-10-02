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
        public List<GlassInformationFile> listofGlass = new List<GlassInformationFile>();

        public void Write(GlassInformation glassInformation)
        {
            Boolean ifAlreadyExist = CorrectIfExist(glassInformation);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream("D:\\data.bin", FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            if (!ifAlreadyExist)
            {
                GlassInformationFile glassInformationFile = new GlassInformationFile();
                glassInformationFile.Name = glassInformation.Name;
                glassInformationFile.Address = glassInformation.Address;
                glassInformationFile.Sum = glassInformation.Percentage;
                glassInformationFile.Times = 1;
                glassInformationFile.Average= glassInformation.Percentage;
                listofGlass.Add(glassInformationFile);
                binaryFormatter.Serialize(fileStream, listofGlass);
            }
            else
            {
                binaryFormatter.Serialize(fileStream, listofGlass);
            }
            fileStream.Flush();
            fileStream.Close();
        }

        public Boolean CorrectIfExist(GlassInformation glassInformation)
        {

            listofGlass = ReadingFromFile.Read();
            foreach (GlassInformationFile glass in listofGlass)
            {
                if (glass.Name.Equals(glassInformation.Name) && glass.Address.Equals(glassInformation.Address))
                {
                    glass.Sum += glassInformation.Percentage;
                    glass.Times++;
                    glass.Average = CalculatingAverage.GetAverage(glass.Sum, glass.Times);
                    return true;
                }
            }
            return false;
        }
    }
}
