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
using Microcharts.Droid;
using Microcharts;
using SkiaSharp;

namespace AndroidApp
{
    [Activity(Label = "DRINKLY")]
    public class MostVisited : Activity
    {
        Button btnGetm;
        Spinner spinnerOrder1;
        Spinner spinnerOrder2;
        Spinner spinnerPeriod;
        ListView listMost;
        string period;
        string order1;
        string order2;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.mostvisitedn);

           // btnGetm = FindViewById<Button>(Resource.Id.btnGetm);
           // spinnerOrder1 = FindViewById<Spinner>(Resource.Id.spinnerOrder1);
           // spinnerOrder2 = FindViewById<Spinner>(Resource.Id.spinnerOrder2);
            spinnerPeriod = FindViewById<Spinner>(Resource.Id.spinnerPeriod);
           // listMost = FindViewById<ListView>(Resource.Id.listMost);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.timePeriod_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerPeriod.Adapter = adapter;
            /*
            var adapter2 = ArrayAdapter.CreateFromResource(this, Resource.Array.timeOrder2_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter2.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerOrder2.Adapter = adapter2;

            var adapter3 = ArrayAdapter.CreateFromResource(this, Resource.Array.timeorder1_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter3.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerOrder1.Adapter = adapter3;*/

            spinnerPeriod.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelectedAsync);
        }
        private async void spinner_ItemSelectedAsync(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            period = spinner.GetItemAtPosition(e.Position).ToString();
            var listMosts = await DataService.GetMostVisited(period);
           // listMost.Adapter = new RestaurantMostAdapter(this, listMosts);
            var entries = new List<Entry>();
            var Colors = new List<string>();
            Colors.Add("#266489");
            Colors.Add("#68B9C0");
            Colors.Add("#F80202");
            Colors.Add("#FAD101");
            Colors.Add("#FB5000");
            int a = 0;
            foreach (Restaurant r in listMosts)
            {
                Entry es = new Entry((float)r.Times)
                {
                    Label = r.Name,
                    ValueLabel = r.Times.ToString() +  " times",
                    Color = SKColor.Parse(Colors.ElementAt(a))
                };
                a++;
                entries.Add(es);
            }
            var chart = new BarChart() { Entries = entries };
            var chartView = FindViewById<ChartView>(Resource.Id.chartView2);
            chartView.Chart = chart;
        }
    }

    
}