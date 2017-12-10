using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string placesId { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public int Sum { get; set; }
        public int Times { get; set; }
        //todo optimizuoti average skaiciavima
    }
}
