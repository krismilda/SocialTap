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
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Support.V4.App;
using AndroidApp.Services;

namespace AndroidApp
{
    [Activity(Label = "DRINKLY")]
    public class Searching : FragmentActivity, IOnMapReadyCallback
    {
        Button btnSearchPl;
        Spinner spinner;
        string type;
        ListView listRestaurants;
        TextView name;
        private GoogleMap nMap;
        private LatLng CurrentLatLng;
        GooglePlacesApiResponse response;
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
            // listRestaurants = FindViewById<ListView>(Resource.Id.listRestaurants);
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
        /*   async void btnSearchPl_ClickAsync(object sender, System.EventArgs e)
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
           }*/
        async void btnSearchPl_ClickAsync(object sender, System.EventArgs e)
        {
            CurrentLocation currentCoordinate = new CurrentLocation();
            string location = await currentCoordinate.GetLocationAsync();
            CurrentLatLng = new LatLng(currentCoordinate.Lat, currentCoordinate.Lng);
            GooglePlacesApiData googleApi = new GooglePlacesApiData();
            response = await googleApi.GetApiResponseData(type.ToLower(), location);
            SetUpMap();
            /*List<Restaurant> restaurantList = new List<Restaurant>();
            for (int i = 0; i < 20; i++)
            {
                Restaurant res = new Restaurant();
                res.Name = response.results[i].name;
                res.Address = response.results[i].vicinity;
                res.Id = 5;
                res.Percentage = 44;
                restaurantList.Add(res);
            }
            listRestaurants.Adapter = new RestaurantAdapter(this, restaurantList);*/
        }
        private void SetUpMap()
        {
            if (nMap == null)
            {
                FragmentManager.FindFragmentById<MapFragment>(Resource.Id.map).GetMapAsync(this);
            }
        }
        public void OnMapReady(GoogleMap googleMap)
        {
            nMap = googleMap;
            CameraUpdate camera = CameraUpdateFactory.NewLatLngZoom(CurrentLatLng, 15);
            nMap.MoveCamera(camera);
            foreach (LocationData r in response.results)
            {
                MarkerOptions options = new MarkerOptions()
               .SetPosition(new LatLng(r.geometry.location.lat, r.geometry.location.lng))
               .SetTitle(r.name)
               .SetIcon(BitmapDescriptorFactory.DefaultMarker(223))
               .SetSnippet(r.vicinity)
           ;

                nMap.AddMarker(options);
            }
            MarkerOptions options8 = new MarkerOptions()
            .SetPosition(CurrentLatLng)
            .SetTitle("Current Location")
            ;
            nMap.AddMarker(options8);

        }

    }
}