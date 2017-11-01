using Logic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        public void Write(RestaurantInformation objectToList, string fileName)
        {
            SocialTapContext db = new SocialTapContext();
            db.RestaurantInformation.Add(objectToList);
            db.SaveChanges();
           /* string cmdString = "INSERT INTO RestaurantData(dateTime, name,address,percentage) VALUES (@val1, @val2, @val3, @val4)";
            string connString = @"Server=(localdb)\MSSQLLocalDB; Database=SocialTap;";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    comm.Connection = conn;
                    comm.CommandText = cmdString;
                    comm.Parameters.AddWithValue("@val1", r.Date);
                    comm.Parameters.AddWithValue("@val2", r.Name);
                    comm.Parameters.AddWithValue("@val3", r.Address);
                    comm.Parameters.AddWithValue("@val4", r.Percentage);
                    conn.Open();
                    comm.ExecuteNonQuery();          
            }
        }

            
            ReadingFromFileDeserialize<T> readingFromFile = new ReadingFromFileDeserialize<T>();
            List<T> listFromFile = readingFromFile.Read(fileName: ConfigurationManager.AppSettings["FileName"]);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None);
            listFromFile.Add(objectToList);
            binaryFormatter.Serialize(fileStream, listFromFile);
            fileStream.Flush();
            fileStream.Close();*/
        }
    }
}
