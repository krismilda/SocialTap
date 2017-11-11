using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using DataModels;


namespace DataAccess
{
    public class SocialTapContext : IdentityDbContext<SocialTapUser>
    {
        public SocialTapContext() : base("name = SocialTapDB")
        {
        }
        public DbSet<Restaurant> RestaurantInformationTable { get; set; }
        public DbSet<Scan> DrinkInfo { get; set; }

    }

}
