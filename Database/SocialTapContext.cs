using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Database
{
    public class SocialTapContext : DbContext
    {
        public SocialTapContext() : base("name=AspNetConnectionString")
        {
        }
        public DbSet<RestaurantInformation> RestaurantInformation { get; set; }
    }
}
