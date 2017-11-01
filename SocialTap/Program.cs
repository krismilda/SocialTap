using Database;
using SocialTap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Services
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
    public class JobSystemContext : DbContext
    {
        public JobSystemContext() : base("name=AspNetConnectionString")
        {
        }
        public DbSet <RestaurantInformation> RestaurantInformation { get; set; }
    }
}
