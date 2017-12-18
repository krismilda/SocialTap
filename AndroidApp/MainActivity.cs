using Android.App;
using Android.Widget;
using Android.OS;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using Android.Gms.Maps;
using Android.Support.V4.App;
using Android.Gms.Maps.Model;

namespace AndroidApp
{
    [Activity(Label = "DRINKLY", Theme = "@android:style/Theme.Light.NoTitleBar")]
    public class MainActivity : Activity
    {
        ImageButton btnUpload;
        ImageButton btnSearch;
        ImageButton btnHistory;
        ImageButton btnBMI;
        ImageButton btnNews;
        Button btnTweet;
        ListView listView1;
        List<Tweet> tweets;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.mainn);

            btnUpload = FindViewById<ImageButton>(Resource.Id.btnUpload);
            btnSearch = FindViewById<ImageButton>(Resource.Id.btnSearch);
            btnHistory = FindViewById<ImageButton>(Resource.Id.btnData);
        //    btnTweet = FindViewById<Button>(Resource.Id.btnTweet);
            btnNews = FindViewById<ImageButton>(Resource.Id.btnNews);
            btnBMI = FindViewById<ImageButton>(Resource.Id.btnBMI);
          ///  listView1 = FindViewById<ListView>(Resource.Id.listView1);
            btnUpload.Click += BtnUpload_Click;
            btnSearch.Click += BtnSearch_Click;
            btnHistory.Click += BtnHistory_Click;
            btnNews.Click += btnNews_Click;
           // btnTweet.Click += btnTweet_ClickAsync;
        }


        void BtnUpload_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(UploadImage));

        }
        void BtnSearch_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(Searching));

        }
        void BtnHistory_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(Historyn));
        }
        void btnNews_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(NewsActivity));
        }
        async void btnTweet_ClickAsync(object sender, System.EventArgs e)
        {
            tweets = await DataService.GetTweetList();
            listView1.Adapter = new Droid.Adapters.TweetAdapter(this, tweets);
        }
        
        public void getApiData() { 
}
        }

    }
 