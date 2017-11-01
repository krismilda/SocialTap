using Database.HistoryData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.File
{
    public class ReadFromDbDrinkInfo<T>
    {
        public List<Drink> Read()
        {
            SocialTapContext db = new SocialTapContext();
            var drinks = from drink in db.DrinkInfo
                              select drink;
            List<Drink> drinkList = drinks.ToList();
           
            return drinkList;
        }
    }
}
