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
using AndroidApp.Droid.Adapters;

namespace AndroidApp
{
    [Activity(Label = "Tweets")]
    public class Tweets : Activity
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
        }
        void BtnSearch_Click(object sender, System.EventArgs e)
        {
    
        }
        void BtnHistory_Click(object sender, System.EventArgs e)
        {
        }
        void BtnBMI_Click(object sender, System.EventArgs e)
        {
        }
        void btnNews_Click(object sender, System.EventArgs e)
        {
        }
        async void btnTweet_ClickAsync(object sender, System.EventArgs e)
        {
            tweets=await DataService.GetTweetList();     
            listView1.Adapter = new TweetAdapter(this, tweets);
        }

    }
}