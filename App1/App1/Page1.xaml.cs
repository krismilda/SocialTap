using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Bar bar = new Bar()
            {
                Name = nameEntry.Text,
                Location = locationEntry.Text
            };

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Bar>();
                var numberOfRows = conn.Insert(bar);

                if (numberOfRows > 0)
                    DisplayAlert("Success", "Bar saved successful", "ok");
                else
                    DisplayAlert("Failure", "Bar failed to be inserted", "X");


            }

        }
    }
}