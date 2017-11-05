using Database.File;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialTap
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            TopList topList= new TopList();
            List <RestaurantInformationAverage> list=topList.GetTopList("Last Month (30 Days)");
            dataTableAllData.Rows.Clear();
            foreach (RestaurantInformationAverage restaurant in list)
            {
                dataTableAllData.Rows.Add(restaurant.Name, restaurant.Address, restaurant.AverageOfPercentage, "-");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Registration().Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }
    }
}
