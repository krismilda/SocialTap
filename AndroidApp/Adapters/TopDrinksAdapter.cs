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

namespace AndroidApp.Adapters
{
    public class TopDrinksAdapter : BaseAdapter<Restaurant>
    {
        List<Restaurant> items;
        Activity context;
        public TopDrinksAdapter(Activity context, List<Restaurant> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override Restaurant this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            View view = convertView;
            if (view == null) // no view to re-use, create new
            view = context.LayoutInflater.Inflate(Resource.Layout.RestaurantDrinks, null);
            view.FindViewById<TextView>(Resource.Id.textDname).Text = item.Name;
          //  view.FindViewById<TextView>(Resource.Id.textDaddress).Text = item.Address;
            view.FindViewById<TextView>(Resource.Id.textDdrink).Text = item.Drink;
            view.FindViewById<TextView>(Resource.Id.textDmili).Text = item.Millimeters.ToString();
            return view;
        }
    }
}