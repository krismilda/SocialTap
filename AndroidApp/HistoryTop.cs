using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidApp.Adapters;

namespace AndroidApp
{
    [Activity(Label = "HistoryTop")]
    public class HistoryTop : Activity
    {
        Button btnMost;
        Button btnTop;
        Button btnMoney;
        Button btnDrinks;
        Button btnGets;
        ListView listTop;
        Spinner spinner3;
        String period;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.History);
            btnGets = FindViewById<Button>(Resource.Id.btnGet);
            btnMost = FindViewById<Button>(Resource.Id.btnMost);
            btnTop = FindViewById<Button>(Resource.Id.btnTop);
            btnMoney = FindViewById<Button>(Resource.Id.btnMoney);
            btnDrinks = FindViewById<Button>(Resource.Id.btnDrinks);
            listTop = FindViewById<ListView>(Resource.Id.listTop);
            spinner3 = FindViewById<Spinner>(Resource.Id.spinner3);
            btnGets.Click += btnGets_ClickAsync;
            btnTop.Click += btnTop_ClickAsync;
            btnMoney.Click += btnMoney_ClickAsync;
            btnDrinks.Click += btnDrinks_ClickAsync;
            btnMost.Click += btnMost_ClickAsync;
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.timePeriod_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner3.Adapter = adapter;
            spinner3.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            period = spinner.GetItemAtPosition(e.Position).ToString();
        }
        async void btnGets_ClickAsync(object sender, System.EventArgs e)
        {

            var tops = await DataService.GetTopRestaurant(period);
            listTop.Adapter = new RestaurantAdapter(this, tops);
        }
        void btnTop_ClickAsync(object sender, System.EventArgs e)
        {
        }
        void btnMoney_ClickAsync(object sender, System.EventArgs e)
        {
        }
        void btnDrinks_ClickAsync(object sender, System.EventArgs e)
        {
        }
        void btnMost_ClickAsync(object sender, System.EventArgs e)
        {
            StartActivity(typeof(MostVisited));
        }

    }
}