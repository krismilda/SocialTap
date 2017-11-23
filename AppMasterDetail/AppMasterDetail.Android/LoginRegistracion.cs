using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net.Http;

namespace AppMasterDetail.Droid
{


    [Activity(Label = "Welcome to DRINKLY")]
    public class LoginRegistration : Activity
    {
        Button btnLogin;
        Button btnRegistration;
        EditText emailInput;
        EditText passwordInput;
        TextView errorMessage;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.main);

            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnRegistration = FindViewById<Button>(Resource.Id.btnRegistration);
            emailInput = FindViewById<EditText>(Resource.Id.emailInput);
            passwordInput = FindViewById<EditText>(Resource.Id.PasswordInput);
            errorMessage = FindViewById<TextView>(Resource.Id.textinput_error);
            btnLogin.Click += BtnLogin_Click;
            btnRegistration.Click += BtnRegistration_Click;
        }

            void BtnLogin_Click(object sender, System.EventArgs e)
            {
            }
            void BtnRegistration_Click(object sender, System.EventArgs e)
            {
                StartActivity(typeof(Registration));
            }
        }
}