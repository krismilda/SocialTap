using Logic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Database.File
{
    public class WritingToFileSerialize <T>
    {
        public void Write(T objectToList, string fileName)
        {
            ReadingFromFileDeserialize<T> readingFromFile = new ReadingFromFileDeserialize<T>();
            List<T> listFromFile = readingFromFile.Read(fileName: ConfigurationManager.AppSettings["FileName"]);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            listFromFile.Add(objectToList);
            binaryFormatter.Serialize(fileStream, listFromFile);
            fileStream.Flush();
            fileStream.Close();
        }
    }
}
