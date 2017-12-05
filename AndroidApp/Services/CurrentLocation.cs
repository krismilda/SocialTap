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
using Plugin.Geolocator;
using System.Threading.Tasks;
using System.Globalization;

namespace AndroidApp.Services
{
    public class CurrentLocation
    {
        public async Task<string> GetLocationAsync()
        {

            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            if (locator.IsGeolocationEnabled)
            {
                var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
                NumberFormatInfo numberFormat = new NumberFormatInfo();
                numberFormat.NumberDecimalSeparator = ".";
                string currentPosition=position.Latitude.ToString(numberFormat) + "," + position.Longitude.ToString(numberFormat);
                return currentPosition;
            }
            return null;
        }
    }
}