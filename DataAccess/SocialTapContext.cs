using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using DataModels;


namespace DataAccess
{
    public class SocialTapContext : IdentityDbContext<SocialTapUser>, ISocialTapContext
    {
        public SocialTapContext() : base("name = SocialTapDB")
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Scan> Scans { get; set; }

        void ISocialTapContext.SaveChanges()
        {
            base.SaveChanges();
        }
    }

}
