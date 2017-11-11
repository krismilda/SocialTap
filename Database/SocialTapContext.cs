using Database;
using Database.HistoryData;
using Database.News;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataBase
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
