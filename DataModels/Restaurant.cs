using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
    public class Restaurant
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public int Percentage { get; set; } //todo optimizuoti average skaiciavima
    }
}
