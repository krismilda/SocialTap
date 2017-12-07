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

namespace AndroidApp.Droid.Adapters
{
    public class TweetAdapter : BaseAdapter<Tweet>
    {
        List<Tweet> items;
        Activity context;
        public TweetAdapter(Activity context, List<Tweet> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override Tweet this[int position]
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
                view = context.LayoutInflater.Inflate(Resource.Layout.TweetList, null);
            view.FindViewById<TextView>(Resource.Id.textView2).Text = item.Text;
            view.FindViewById<TextView>(Resource.Id.textView1).Text = item.CreatedAt.ToString();
            view.FindViewById<TextView>(Resource.Id.textView3).Text = item.FavoriteCount.ToString();

            return view;
        }
    }
}