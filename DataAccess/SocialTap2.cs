using DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SocialTap2: DbContext
    {
        public SocialTap2() : base("name = SocialTapDB")
        {
        }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Scan> Scans { get; set; }

    }

    
    
}
