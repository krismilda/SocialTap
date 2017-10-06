using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;
using System.Diagnostics;
using System.Globalization;

namespace Services
{
    public class CurrentCoordinate
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public void CalculateCurrentCoordinates()
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();
          /*  do
            {
                watcher.TryStart(true, TimeSpan.FromMilliseconds(2000));

            } while (watcher.Status.ToString().Equals("NoData"));


            GeoCoordinate coordinate = watcher.Position.Location;
            */
        //    if (coordinate.IsUnknown != true)
            {
               
                Latitude = 54.734615;
                Longitude = 25.247996;
            }
        }
    }
}