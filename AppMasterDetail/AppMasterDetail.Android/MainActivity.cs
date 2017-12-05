using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.Geolocator;

namespace AppMasterDetail.Droid
{

    [Activity(Label = "AppMasterDetail", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        Button btnRegistration;
        Button btnLogin;
        TextView EmailInput;
        EditText PasswordInput;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;


            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            StartActivity(typeof(Tweets));
            getLocationAsync();
        }

        public async System.Threading.Tasks.Task getLocationAsync()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                if (locator.IsGeolocationEnabled)
                {
                    var position = await locator.GetPositionAsync();
                    position.ToString();
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Geolocation is disabled!");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Unable to get location, may need to increase timeout: " + ex);
            }
        }
    }

}
