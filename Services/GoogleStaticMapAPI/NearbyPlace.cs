using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class NearbyPlace
    {
        public String name { get; set; }
        public String address { get; set; }
        public String percentage { get; set; }
        public String coordinates { get; set; }

        public NearbyPlace(String name, String address, string coordinates)
        {
            this.name = name;
            this.address = address;
            this.coordinates = coordinates;
        }
    }
}
