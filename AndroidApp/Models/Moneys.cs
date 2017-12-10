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

namespace AndroidApp.Models
{
    public class Moneys
    {
        public string Drink { get; set; }
        public double Money_paid { get; set; }
        public double Money_lost { get; set; }
    }
}