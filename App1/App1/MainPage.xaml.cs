﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            slider.Value = 0.5;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Bar>();

                var bars = conn.Table<Bar>().ToList();
                barsListView.ItemsSource = bars;
            }
                    
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Title", "Hello world", "ok");
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page1());
        }
    }
}
