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
    public class NewAdapter : BaseAdapter<News>
    {
        List<News> items;
        Activity context;
        public NewAdapter(Activity context, List<News> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override News this[int position]
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
                view = context.LayoutInflater.Inflate(Resource.Layout.NewModel, null);
            view.FindViewById<TextView>(Resource.Id.tnDate).Text = item.Date.ToString();
            view.FindViewById<TextView>(Resource.Id.tnUser).Text = item.Username;
            view.FindViewById<TextView>(Resource.Id.tnText).Text = item.Text;

            return view;
        }
    }
}