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
    [Activity(Label = "DRINKLY")]
    public class Money : Activity
    {
        Button buttonGetInfo;
        TextView textall;
        TextView textlo;
        ListView listmoney;
        Spinner spinner7;
        string period;
        internal string Drink;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Money);
            // Create your application here

            buttonGetInfo = FindViewById<Button>(Resource.Id.btnGetInfo);
            textall = FindViewById<TextView>(Resource.Id.textdlo);
            textlo = FindViewById<TextView>(Resource.Id.textlo);
            listmoney = FindViewById<ListView>(Resource.Id.listmoney);
            spinner7 = FindViewById<Spinner>(Resource.Id.spinner7);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.timePeriod2_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner7.Adapter = adapter;
            buttonGetInfo.Click += buttonGetInfo_ClickAsync;
            spinner7.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
        }
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            period = spinner.GetItemAtPosition(e.Position).ToString();
        }
        async void buttonGetInfo_ClickAsync(object sender, System.EventArgs e)
        {
            var allData = await DataService.GetMoneyCommon(period);
            textall.Text = allData.Money_paid.ToString();
            textlo.Text= allData.Money_lost.ToString();
            var listDrink = await DataService.GetMoneyDrink(period);
            listmoney.Adapter = new MoneyAdapter(this, listDrink);
        }
    }
}