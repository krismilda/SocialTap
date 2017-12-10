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
using AndroidApp.Models;

namespace AndroidApp.Adapters
{
    public class MoneyAdapter : BaseAdapter<Moneys>
    {
        List<Moneys> items;
        Activity context;
        public MoneyAdapter(Activity context, List<Moneys> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override Moneys this[int position]
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
                view = context.LayoutInflater.Inflate(Resource.Layout.MoneyModel, null);
            view.FindViewById<TextView>(Resource.Id.textmd).Text = item.Drink;
            view.FindViewById<TextView>(Resource.Id.textmm).Text = Math.Round(item.Money_paid, 2).ToString();
            view.FindViewById<TextView>(Resource.Id.textml).Text = Math.Round(item.Money_lost, 2).ToString();

            return view;
        }
    }
}