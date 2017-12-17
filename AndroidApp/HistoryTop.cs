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
using AndroidApp;

namespace AndroidApp
{
    [Activity(Label = "HistoryTop", Theme = "@android:style/Theme.Light.NoTitleBar")]
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
            SetContentView(Resource.Layout.topRestaurantsn);
            listTop = FindViewById<ListView>(Resource.Id.listTop);
            spinner3 = FindViewById<Spinner>(Resource.Id.spinner3);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.timePeriod_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner3.Adapter = adapter;
            spinner3.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelectedAsync);
        }

        private async void spinner_ItemSelectedAsync(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            period = spinner.GetItemAtPosition(e.Position).ToString();
            var tops = await DataService.GetTopRestaurant(period);
            listTop.Adapter = new RestaurantAdapter(this, tops);
        }

    }
}