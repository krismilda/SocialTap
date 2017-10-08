using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.Name = name;
            this.Address = address;
            this.Coordinates = coordinates;
        }
    }
}
