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
            db.RestaurantInformationTable.Add(objectToList);
            db.SaveChanges();
        }
    }
}
