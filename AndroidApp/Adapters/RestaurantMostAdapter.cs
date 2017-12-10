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
    public class RestaurantMostAdapter : BaseAdapter<Restaurant>
    {
        List<Restaurant> items;
        Activity context;
        public RestaurantMostAdapter(Activity context, List<Restaurant> items)
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
                view = context.LayoutInflater.Inflate(Resource.Layout.RestaurantMost, null);
            view.FindViewById<TextView>(Resource.Id.texttmname).Text = item.Name;
            view.FindViewById<TextView>(Resource.Id.texttmaddress).Text = item.Address;
            view.FindViewById<TextView>(Resource.Id.texttmtimes).Text = item.Times.ToString();
            view.FindViewById<TextView>(Resource.Id.texttmper).Text = item.Average.ToString();
            return view;
        }
    }
}