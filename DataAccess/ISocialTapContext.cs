using DataModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public interface ISocialTapContext : IDisposable
    {
        DbSet<Restaurant> Restaurants { get; set; }
        DbSet<Scan> Scans { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        void SaveChanges();
    }
}
