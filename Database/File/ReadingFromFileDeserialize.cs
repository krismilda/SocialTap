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
    public class ReadingFromFileDeserialize <T>
    {
        public List<RestaurantInformation> Read(String fileName)
        {
            SocialTapContext db = new SocialTapContext();
            var restaurants = from restaurant in db.RestaurantInformation
                              select restaurant;
            List<RestaurantInformation> restaurantList = restaurants.ToList();
           /*
            List<T> glassInformation = new List<T>();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);
            glassInformation = (List<T>)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();*/
            return restaurantList;
        }
    }
}

