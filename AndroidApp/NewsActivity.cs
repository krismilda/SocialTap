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

namespace AndroidApp
{
    [Activity(Label = "NewsActivity")]
    public class NewsActivity : Activity
    {
        Button btnWriteNew;
        Button btnGetNews;
        TextView text;
        ListView listNews;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.NewsList);

            btnWriteNew = FindViewById<Button>(Resource.Id.btnWrite);
            btnGetNews = FindViewById<Button>(Resource.Id.btnGet);
            text = FindViewById<TextView>(Resource.Id.text);
            listNews = FindViewById<ListView>(Resource.Id.listNews);
            btnWriteNew.Click += btnWriteNew_Click;
            btnGetNews.Click += btnGetNews_Click;
        }
        public void btnWriteNew_Click(object sender, System.EventArgs e)
        {
            
            News news = new News();
            news.Date = DateTime.Today;
            news.Text = "Labas";
            DataService.AddNew(news);
        }
        public void btnGetNews_Click(object sender, System.EventArgs e)
        {

        }
    }
}