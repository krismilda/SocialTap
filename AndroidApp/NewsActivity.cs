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
    public class NewsActivity : Activity
    {
        Button btnWriteNew;
        Button btnGetNews;
        EditText textNew;
        ListView listNews;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.NewsList);

            btnWriteNew = FindViewById<Button>(Resource.Id.btnWrite);
            btnGetNews = FindViewById<Button>(Resource.Id.btnGet);
            textNew = FindViewById<EditText>(Resource.Id.textNew);
            listNews = FindViewById<ListView>(Resource.Id.listNews);
            btnWriteNew.Click += btnWriteNew_Click;
            btnGetNews.Click += btnGetNews_ClickAsync;
        }
        public void btnWriteNew_Click(object sender, System.EventArgs e)
        {
            DataService.AddNew(textNew.Text);
            textNew.Text = "";
        }
        public async void btnGetNews_ClickAsync(object sender, System.EventArgs e)
        {
            var newsList= await DataService.GetNewsList();
            listNews.Adapter = new NewAdapter(this, newsList);
        }
    }
}