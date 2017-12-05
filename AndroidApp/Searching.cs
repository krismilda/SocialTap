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
using System.Threading.Tasks;
using AndroidApp.Adapters;

namespace AndroidApp
{
    [Activity(Label = "Searching")]
    public class Searching : Activity
    {
        Button btnSearchPl;
        Spinner spinner;
        string type;
        ListView listRestaurants;
        TextView name;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.SearchList);
            spinner = FindViewById<Spinner>(Resource.Id.spinner);
            btnSearchPl = FindViewById<Button>(Resource.Id.btnSearchPl);
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            name = FindViewById<TextView>(Resource.Id.tname);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.car_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            listRestaurants = FindViewById<ListView>(Resource.Id.listRestaurants);
            spinner.Adapter = adapter;
            btnSearchPl.Click += btnSearchPl_ClickAsync;
        
        }
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            type = spinner.GetItemAtPosition(e.Position).ToString();
            string toast = string.Format("Selected type is {0}", type);
            Toast.MakeText(this, toast, ToastLength.Long).Show();
            
        }
        async void btnSearchPl_ClickAsync(object sender, System.EventArgs e)
        {
            GooglePlacesApiData googleApi = new GooglePlacesApiData();
            GooglePlacesApiResponse response = await googleApi.GetApiResponseData(type.ToLower());
            List<Restaurant> restaurantList = new List<Restaurant>();
            for(int i=0; i<20; i++)
            {
                Restaurant res = new Restaurant();
                res.Name = response.results[i].name;
                res.Address = response.results[i].vicinity;
                res.Id = 5;
                res.Percentage = 44;
                restaurantList.Add(res);
            }
            listRestaurants.Adapter = new RestaurantAdapter(this, restaurantList);
        }
    }
}