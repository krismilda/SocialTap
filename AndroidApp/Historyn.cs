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

namespace AndroidApp
{
[Activity(Label = "HistoryTop", Theme = "@android:style/Theme.Light.NoTitleBar")]
public class Historyn : Activity
{
    ImageButton btnMost;
    ImageButton btnTop;
        ImageButton btnMoney;
        ImageButton btnDrinks;

    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.historyn);
        btnMost = FindViewById<ImageButton>(Resource.Id.btnMost);
        btnTop = FindViewById<ImageButton>(Resource.Id.btnTop);
        btnMoney = FindViewById<ImageButton>(Resource.Id.btnMoney);
        btnDrinks = FindViewById<ImageButton>(Resource.Id.btnDrinks);
      
        btnTop.Click += btnTop_ClickAsync;
        btnMoney.Click += btnMoney_ClickAsync;
        btnDrinks.Click += btnDrinks_ClickAsync;
        btnMost.Click += btnMost_ClickAsync;

    }
    void btnTop_ClickAsync(object sender, System.EventArgs e)
    {
        StartActivity(typeof(HistoryTop));
    }
    void btnMoney_ClickAsync(object sender, System.EventArgs e)
    {
        StartActivity(typeof(Money));
    }
    void btnDrinks_ClickAsync(object sender, System.EventArgs e)
    {
        StartActivity(typeof(TopDrinks));
    }
    void btnMost_ClickAsync(object sender, System.EventArgs e)
    {
        StartActivity(typeof(MostVisited));
    }

}
}