﻿using System;
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
using AndroidApp.Services;

using System.IO;


namespace AndroidApp
{
    [Activity(Label = "DRINKLY", Theme = "@android:style/Theme.Light.NoTitleBar")]
    public class UploadImage : Activity
    {
        Button btnCalculate;
        Button btnMake;
        EditText textMili;
        EditText textDrink;
        Spinner spinner1;
        TextView textmil;
        TextView textper;
        TextView textres;
        TextView textresa;
        ImageView imageve;
        Button btnSelect;
        Bitmap bitmap;
        string drink;
        static int i=0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.photoAnalysisn);

            // Create your application here

          //  btnCalculate = FindViewById<Button>(Resource.Id.btnCalculate);
            btnMake = FindViewById<Button>(Resource.Id.btnMakes);
            btnSelect = FindViewById<Button>(Resource.Id.btnSelect);
            textMili = FindViewById<EditText>(Resource.Id.textIMilis);
            textDrink = FindViewById<EditText>(Resource.Id.textDrink);
            spinner1 = FindViewById<Spinner>(Resource.Id.spinner4);
            textres = FindViewById<TextView>(Resource.Id.textres);
            textresa = FindViewById<TextView>(Resource.Id.textresa);
            textper = FindViewById<TextView>(Resource.Id.textper);
            textmil= FindViewById<TextView>(Resource.Id.textmil);
            imageve = FindViewById<ImageView>(Resource.Id.imageve);
            var adapter = ArrayAdapter.CreateFromResource(this, Resource.Array.drinks_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner1.Adapter = adapter;
           // btnCalculate.Click += btnCalculate_ClickAsync;
            btnMake.Click += btnMake_ClickAsync;
            btnSelect.Click += btnSelect_ClickAsync;
            imageve.SetImageDrawable(null);
            spinner1.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
        }
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;
            drink = spinner.GetItemAtPosition(e.Position).ToString();
        }
        async void Calculate()
        {
            byte[] bitmapData;
            CurrentLocation currentLocation = new CurrentLocation();
            string location = await currentLocation.GetLocationAsync();
            GooglePlacesApiData placesData = new GooglePlacesApiData();
            GooglePlacesApiResponse response= await placesData.GetApiResponseData("food", location);
            textres.Text = response.results[0].name;
            textresa.Text = response.results[0].vicinity;
            string restaurantId = response.results[0].place_id;
            using (var stream = new MemoryStream())
            {
                bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                bitmapData = stream.ToArray();
            }
            int percentage=100;
            // var percentage = await DataService.Upload(bitmapData);
            if (i == 0)
            {
                percentage = 90;
                i++;
            }
            if (i == 1)
            {
                percentage = 54;
                i++;
            }
            if (i == 2)
                {
                    percentage = 90;
                    i++;
                }
            
            await DataService.PostScan(percentage, drink, response.results[0].name, response.results[0].vicinity, response.results[0].place_id, textMili.Text, textDrink.Text);
            textper.Text = percentage.ToString();
            double mili;
            mili= Double.Parse(textMili.Text);
            textmil.Text = (mili * (percentage * 0.01)).ToString();
            Boolean b = await DataService.MaxAlco();
            if (b == true)
            {
                AlertDialog.Builder builder;
                builder = new AlertDialog.Builder(this);
                builder.SetTitle("Too Much Alcohol!!!");
                builder.SetMessage("That's way too much alcohol for you this week...");
                builder.SetCancelable(false);
                builder.SetPositiveButton("OK", delegate { });
                Dialog dialog = builder.Create();
                dialog.Show();
            }
        }
        async void btnSelect_ClickAsync(object sender, System.EventArgs e)
        {
            imageve.SetImageDrawable(null);
            if (CrossMedia.Current.IsPickPhotoSupported)
            {
                var photo= await CrossMedia.Current.PickPhotoAsync();
                var filePath = photo.Path;
                bitmap = BitmapFactory.DecodeFile(filePath);
                imageve.SetImageBitmap(Bitmap.CreateScaledBitmap(bitmap, 300, 500, false));

            }
            byte[] bitmapData;
            using (var stream = new MemoryStream())
            {
                bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                bitmapData = stream.ToArray();
            }
            Calculate();
        }
        async void btnMake_ClickAsync(object sender, System.EventArgs e)
        {
            imageve.SetImageDrawable(null);
            if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported)
            {
                var mediaOptions = new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Drinks",
                    Name = $"{DateTime.UtcNow}.jpg"
                };

                var file = await CrossMedia.Current.TakePhotoAsync(mediaOptions);
                var filePath = file.Path;
                bitmap = BitmapFactory.DecodeFile(filePath);

                imageve.SetImageBitmap(Bitmap.CreateScaledBitmap(bitmap, 300, 500, false));
            }
            Calculate();
        }
    }


}