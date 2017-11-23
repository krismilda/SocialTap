using Database.News;
using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.File
{
    public class WritingNewToDatabase : IDisposable
    {
        private SocialTapContext _db = new SocialTapContext();
        public void Dispose()
        {
            _db.Dispose();
        }

        public void Write(New newToFile)
        {    
            _db.NewTable.Add(newToFile);
            _db.SaveChanges();
        }
    }
}
