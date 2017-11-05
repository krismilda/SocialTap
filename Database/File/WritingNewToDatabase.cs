using Database.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.File
{
    public class WritingNewToDatabase
    {
        public void Write(New newToFile)
        {
            SocialTapContext db = new SocialTapContext();
            db.NewTable.Add(newToFile);
            db.SaveChanges();
        }
    }
}
