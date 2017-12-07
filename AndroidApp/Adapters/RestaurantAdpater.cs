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
    public class RestaurantAdapter : BaseAdapter<Restaurant>
    {
        List<Restaurant> items;
        Activity context;
        public RestaurantAdapter(Activity context, List<Restaurant> items)
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
                view = context.LayoutInflater.Inflate(Resource.Layout.Restaurants, null);
            view.FindViewById<TextView>(Resource.Id.tname).Text = item.Name;
            view.FindViewById<TextView>(Resource.Id.taddress).Text = item.Address;
            view.FindViewById<TextView>(Resource.Id.tpercentage).Text = item.Percentage.ToString();
            view.FindViewById<TextView>(Resource.Id.ticon).Text = item.Id.ToString();

            return view;
        }
    }
}