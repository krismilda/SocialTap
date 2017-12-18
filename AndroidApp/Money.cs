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
using AndroidApp.Models;
using SkiaSharp;
using Microcharts.Droid;

namespace AndroidApp
{
    [Activity(Label = "DRINKLY", Theme = "@android:style/Theme.Light.NoTitleBar")]
    public class Money : Activity
    {
        //Button buttonGetInfo;
        TextView textall;
        TextView textlo;
       // ListView listmoney;
        Spinner spinner7;
        string period;
        internal string Drink;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.moneyn);
            // Create your application here

           // buttonGetInfo = FindViewById<Button>(Resource.Id.btnGetInfo);
            textall = FindViewById<TextView>(Resource.Id.textdlo);
            textlo = FindViewById<TextView>(Resource.Id.textlo);
           // listmoney = FindViewById<ListView>(Resource.Id.listmoney);
            spinner7 = FindViewById<Spinner>(Resource.Id.spinner7);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.timePeriod2_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner7.Adapter = adapter;
           // buttonGetInfo.Click += buttonGetInfo_ClickAsync;
            spinner7.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelectedAsync);
        }
        private async void spinner_ItemSelectedAsync(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            period = spinner.GetItemAtPosition(e.Position).ToString();
            var allData = await DataService.GetMoneyCommon(period);
            textall.Text = allData.Money_paid.ToString();
            textlo.Text = allData.Money_lost.ToString();
            var listDrink = await DataService.GetMoneyDrink(period);

            var entries = new List<Entry>();
            var entries2 = new List<Entry>();
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
            foreach (Moneys r in listDrink)
            {
                Entry es = new Entry((float)r.Money_paid)
                {
                    Label = r.Drink,
                    ValueLabel = Math.Round(r.Money_paid, 2).ToString() + " EUR",
                    Color = SKColor.Parse(Colors.ElementAt(a))
                };
                entries.Add(es);
                Entry es2 = new Entry((float)r.Money_lost)
                {
                    Label = r.Drink,
                    ValueLabel = Math.Round(r.Money_lost, 2).ToString() + " EUR",
                    Color = SKColor.Parse(Colors.ElementAt(a))
                };
                a++;
                entries2.Add(es2);
            }
            var chart = new DonutChart() { Entries = entries };
            var chart2 = new DonutChart() { Entries = entries2 };
            var chartView3 = FindViewById<ChartView>(Resource.Id.chartView3);
            var chartView4 = FindViewById<ChartView>(Resource.Id.chartView4);
            chartView3.Chart = chart;
            chartView4.Chart = chart2;
        }
    }

    }
