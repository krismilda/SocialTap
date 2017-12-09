using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class NewsRepository : BaseRepository<NewsRepository>
    {
        public void Add(New news)
        {
            _context.News.Add(news);
            _context.SaveChanges();
        }
    }
}
