using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Database.HistoryData;
using Database.News;


namespace Database
{
    public class SocialTapContext : DbContext
    {
        public SocialTapContext() : base("name=AspNetConnectionString")
        {
        }
        public DbSet<RestaurantInformation> RestaurantInformationTable { get; set; }
        public DbSet<Drink> DrinkInfo { get; set; }
        public DbSet<New> NewTable { get; set; }

    }
    
}
