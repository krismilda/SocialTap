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
    [Activity(Label = "ImageRecognition")]
    public class ImageRecognition : Activity
    {


        Button btnTackPic;
        Uri photoPath;
        ImageView ivThumbnailPhoto;

        static int TAKE_PICTURE = 1;

        protected void onCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.photo);

            // Get reference to views

            btnTackPic = (Button)FindViewById(Resource.Id.btnphoto);
            ivThumbnailPhoto = (ImageView)FindViewById(Resource.Id.imagev);
            btnTackPic.Click += onClick;

        }


        void onClick(object sender, System.EventArgs e)
            {
            // TODO Auto-generated method stub


            Intent cameraIntent = new Intent();
            StartActivityForResult(cameraIntent, TAKE_PICTURE);
       

        }


        protected void onActivityResult(int requestCode, int resultCode, Intent intent)
{


    if (requestCode == TAKE_PICTURE )
    {
                Bitmap photo = (Bitmap)intent.Extras.Get("data");
        ivThumbnailPhoto.SetImageBitmap(photo);
      //  ivThumbnailPhoto.SetVisibility(imagev.VISIBLE);



    }
}
}
}