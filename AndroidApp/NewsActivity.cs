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
    [Activity(Label = "DRINKLY", Theme = "@android:style/Theme.Light.NoTitleBar")]
    public class NewsActivity : Activity
    {
        Button btnWriteNew;
        Button btnGetNews;
        EditText textNew;
        ListView listNews;
        ListView listView1;
        List<Tweet> tweets;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Newsn);
            listView1 = FindViewById<ListView>(Resource.Id.listView1);
            btnWriteNew = FindViewById<Button>(Resource.Id.btnWrite);
            textNew = FindViewById<EditText>(Resource.Id.textNew);
            listNews = FindViewById<ListView>(Resource.Id.listNews);
            btnWriteNew.Click += btnWriteNew_Click;
            GetNews();
            GetTweets();
        }
        public void btnWriteNew_Click(object sender, System.EventArgs e)
        {
            DataService.AddNew(textNew.Text);
            textNew.Text = "";
            GetNews();
        }
        public async void GetNews()
        {
            var newsList= await DataService.GetNewsList();
            listNews.Adapter = new NewAdapter(this, newsList);
        }
        async void GetTweets()
        {
            tweets = await DataService.GetTweetList();
            listView1.Adapter = new Droid.Adapters.TweetAdapter(this, tweets);
        }
    }
}