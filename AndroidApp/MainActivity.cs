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
    [Activity(Label = "DRINKLY", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button btnUpload;
        Button btnSearch;
        Button btnHistory;
        Button btnBMI;
        Button btnNews;
        Button btnTweet;
        ListView listView1;
        List<Tweet> tweets;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainWindow);

           btnUpload = FindViewById<Button>(Resource.Id.btnUpload);
            btnSearch = FindViewById<Button>(Resource.Id.btnSearch);
            btnHistory = FindViewById<Button>(Resource.Id.btnData);
            btnTweet = FindViewById<Button>(Resource.Id.btnTweet);
            btnNews = FindViewById<Button>(Resource.Id.btnNews);
            btnBMI = FindViewById<Button>(Resource.Id.btnBMI);
            listView1 = FindViewById<ListView>(Resource.Id.listView1);
            btnUpload.Click += BtnUpload_Click;
            btnSearch.Click += BtnSearch_Click;
            btnHistory.Click += BtnHistory_Click;
            btnBMI.Click += BtnBMI_Click;
            btnNews.Click += btnNews_Click;
            btnTweet.Click += btnTweet_ClickAsync;
          
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
            StartActivity(typeof(HistoryTop));
        }
        void BtnBMI_Click(object sender, System.EventArgs e)
        {
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
 