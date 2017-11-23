using Autofac;
using DataAccess;
using SocialTap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Services
{
    static class Program
    {
        static Autofac.IContainer Container { get; set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm("aaaa"));

            var builder = new ContainerBuilder();
            builder.RegisterType<SocialTapContext>().As<ISocialTapContext>();
        }
    }

}
