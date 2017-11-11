using DataBase;
using Database.HistoryData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.File
{
    public class WriteToDbDrinkInfo<T>
    {
        public void Write(Drink objectToList)
        {
            SocialTapContext db = new SocialTapContext();
            db.DrinkInfo.Add(objectToList);
            db.SaveChanges();
        }
    }
}