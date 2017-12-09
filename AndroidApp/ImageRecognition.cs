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
using Plugin.Media;
using Android.Graphics;
using Android.Support.V4.Widget;
using Xamarin.Forms.PlatformConfiguration;

namespace AndroidApp
{

    [Activity(Label = "DRINKLY")]

    public class ImageRecognition : Activity
    {



        Button btnCalculate;
        Button btnMake;
        EditText textMili;
        EditText textDrink;
        Spinner spinner1;


        protected void onCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.PhotoAnalysis);
            btnCalculate = FindViewById<Button>(Resource.Id.btnCalculate);
            btnMake = FindViewById<Button>(Resource.Id.btnMakes);
            textMili = FindViewById<EditText>(Resource.Id.textIMilis);
            textDrink = FindViewById<EditText>(Resource.Id.textDrink);
            spinner1 = FindViewById<Spinner>(Resource.Id.spinner1);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.drinks_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner1.Adapter = adapter;
            btnCalculate.Click += btnCalculate_Click;
            btnMake.Click += btnMake_ClickAsync;
        }


        void btnCalculate_Click(object sender, System.EventArgs e)
        {

        }
        async void btnMake_ClickAsync(object sender, System.EventArgs e)
        {

        }
    }

}