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
    public class TopDrinks : Activity
    {
        Button btnmostD;
        Spinner spinnerPeriod;
        ListView listDrink;
        string period;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TopDrinks);

            btnmostD = FindViewById<Button>(Resource.Id.btnmostD);
            spinnerPeriod = FindViewById<Spinner>(Resource.Id.spinnerperiodD);
            listDrink = FindViewById<ListView>(Resource.Id.listDrinks);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.timePeriod2_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinnerPeriod.Adapter = adapter;

            spinnerPeriod.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            btnmostD.Click += btnmostD_ClickAsync;
            // Create your application here
        }
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            period = spinner.GetItemAtPosition(e.Position).ToString();
        }
        async void btnmostD_ClickAsync(object sender, System.EventArgs e)
        {
            var listDrinks = await DataService.GetTopDrinks(period);
            listDrink.Adapter= new TopDrinksAdapter(this, listDrinks);
        }
    }
}