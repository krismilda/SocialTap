using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class RestaurantScan
    {
        public string Name { get; set; }
        public string Place_Id { get; set; }
        public string Address { get; set; }
        public int Percentage { get; set; }
        public string User_id  { get; set; }
        public double Millimeters { get; set; }
        public string Drink { get; set; }
        public double Price { get; set; }
    }
}
