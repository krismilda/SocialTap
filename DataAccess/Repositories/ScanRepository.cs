using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ScanRepository : BaseRepository<ScanRepository>
    {
        public void Add(Scan scan)
        {
            _context.Scans.Add(scan);
            _context.SaveChanges();
        }
    }
}
