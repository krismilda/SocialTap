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
using Microcharts;
using SkiaSharp;
using Microcharts.Droid;

namespace AndroidApp
{
    [Activity(Label = "DRINKLY", Theme = "@android:style/Theme.Light.NoTitleBar")]
    public class TopDrinks : Activity
    {
        Button btnmostD;
        Spinner spinnerPeriod;
        ListView listDrink;
        string period;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.topDrinksn);

            btnmostD = FindViewById<Button>(Resource.Id.btnmostD);
            spinnerPeriod = FindViewById<Spinner>(Resource.Id.spinnerperiodD);
            listDrink = FindViewById<ListView>(Resource.Id.listDrinks);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.timePeriod2_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerPeriod.Adapter = adapter;

            spinnerPeriod.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelectedAsync);
          //  btnmostD.Click += btnmostD_ClickAsync;
            // Create your application here
        }
        private async void spinner_ItemSelectedAsync(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            period = spinner.GetItemAtPosition(e.Position).ToString();
            var listDrinks = await DataService.GetTopDrinks(period);
            var listDrinks2 = await DataService.GetTopDrinks2(period);
            var entries = new List<Entry>();
            listDrink.Adapter = new TopDrinksAdapter(this, listDrinks2);
            var Colors = new List<string>();
            Colors.Add("#266489");
            Colors.Add("#68B9C0");
            Colors.Add("#F80202");
            Colors.Add("#FAD101");
            Colors.Add("#BEF781");
            Colors.Add("#848484");
            Colors.Add("#0174DF");
            Colors.Add("#B45F04");
            int a = 0;
            foreach (Restaurant r in listDrinks)
            {
                Entry es = new Entry((float)r.Sum)
                {
                    Label = r.Drink,
                    ValueLabel = r.Sum.ToString()+" ml",
                    Color = SKColor.Parse(Colors.ElementAt(a))
                };
                a++;
                entries.Add(es);
            }
            var chart = new DonutChart() { Entries = entries };
            var chartView = FindViewById<ChartView>(Resource.Id.chartView);
            chartView.Chart = chart;
        }
    }
}