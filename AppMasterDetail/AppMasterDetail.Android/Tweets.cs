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

namespace AppMasterDetail.Droid
{
    [Activity(Label = "Tweets")]
    public class Tweets : Activity
    {
        Button btnUpload;
        Button btnSearch;
        Button btnHistory;
        Button btnBMI;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MainWindow);

            btnUpload = FindViewById<Button>(Resource.Id.btnUploadData);
            btnSearch= FindViewById<Button>(Resource.Id.btnSearch);
            btnHistory = FindViewById<Button>(Resource.Id.btnHistory);
            btnBMI = FindViewById<Button>(Resource.Id.btnBMI);
            btnUpload.Click += BtnUpload_Click;
            btnSearch.Click += BtnSearch_Click;
            btnHistory.Click += BtnHistory_Click;
            btnBMI.Click += BtnBMI_Click;

             DataService.GetTweetList();
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
    }
}