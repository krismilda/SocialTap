using Database.News;
using System;
using System.Collections.Generic;
using System.Linq;
using DataBase;
using System.Text;
using System.Threading.Tasks;

namespace Database.File
{
    public class ReadingNewFromDatabase
    {
        public List<New> Read(string time)
        {
            DateTime date = new DateTime();
            switch (time)
            {
                case "Today":
                    date = DateTime.Today;

                    break;
                case "Yesterday":
                    date = DateTime.Today.AddDays(-1);
                    break;

            }
            SocialTapContext db = new SocialTapContext();
            var allNews = from news in db.NewTable
                          where news.Date==date
                          select news;
            List<New> newList = allNews.ToList();
            return newList;
        }
    }
}
