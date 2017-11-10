using System;

namespace Services
{
    public class NearbyPlace
    {
        public String Name { get; set; }
        public String Address { get; set; }
        public String Percentage { get; set; }
        public String Coordinates { get; set; }

        public NearbyPlace(String name, String address, string coordinates)
        {
            Name = name;
            Address = address;
            Coordinates = coordinates;
        }
    }
}
