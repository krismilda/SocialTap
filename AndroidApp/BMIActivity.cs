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
using AndroidApp.Services.BMI;

namespace AndroidApp
{
    [Activity(Label = "BMI calculator")]
    public class BMIActivity : Activity
    {
        Button btnCount;
        EditText height;
        EditText weight;
        EditText age;
        TextView yourBmi;
        TextView normal;
        double bmi;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.BMIpage);

            height = FindViewById<EditText>(Resource.Id.editText1);
            weight = FindViewById<EditText>(Resource.Id.editText2);
            age = FindViewById<EditText>(Resource.Id.editText3);
            yourBmi = FindViewById<TextView>(Resource.Id.textView4);
            normal = FindViewById<TextView>(Resource.Id.textView5);

            btnCount = FindViewById<Button>(Resource.Id.button1);
            btnCount.Click += BtnCount_ClickAsync;
        }


        async void BtnCount_ClickAsync(object sender, System.EventArgs e)
        {

            int he = int.Parse(height.Text.ToString());
            int we = int.Parse(weight.Text.ToString());
            int ag = int.Parse(age.Text.ToString());
           
            bmi = await DataService.GetBMI(we, he);
            CategoryOfAge coa = new CategoryOfAge();
            int ageCat = coa.GetCategoryOfAge(ag);

            yourBmi.Text = "Your BMI: " + bmi.ToString();
            normal.Text = "Perfect BMI in your age:" + ageCat.ToString();
        }

    }
}