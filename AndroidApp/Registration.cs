﻿using System;
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
    [Activity(Label = "DRINKLY", Theme = "@android:style/Theme.Light.NoTitleBar")]
    public class Registration : Activity
    {
        Button btnRegister;
        EditText InputEmail;
        EditText InputPassword;
        TextView InputConfirmPassword;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.registracion);

            btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            InputEmail = FindViewById<EditText>(Resource.Id.InputEmail);
            InputPassword = FindViewById<EditText>(Resource.Id.InputPassword);
            InputConfirmPassword= FindViewById<EditText>(Resource.Id.InputConfirmPassword);
            btnRegister.Click += BtnRegistration_Click;
        }
        async void BtnRegistration_Click(object sender, System.EventArgs e)
        {
            var response=await DataService.Register(InputEmail.Text, InputPassword.Text, InputConfirmPassword.Text);
            if (response.IsSuccessStatusCode)
            {
                StartActivity(typeof(MainActivity));
            }
        }
    }
}