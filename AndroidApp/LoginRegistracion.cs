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

namespace AndroidApp
{


    [Activity(Label = "DRINKLY", MainLauncher = true, Theme = "@android:style/Theme.Light.NoTitleBar")]
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
            SetContentView(Resource.Layout.loginn);

            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnRegistration = FindViewById<Button>(Resource.Id.btnRegistration);
            emailInput = FindViewById<EditText>(Resource.Id.emailInput);
            passwordInput = FindViewById<EditText>(Resource.Id.PasswordInput);
            //  errorMessage = FindViewById<TextView>(Resource.Id.textinput_error);
            btnLogin.Click += BtnLogin_Click;
            btnRegistration.Click += BtnRegistration_Click;
        }

        void BtnLogin_Click(object sender, System.EventArgs e)
        {
            var response = DataService.Login(emailInput.Text, passwordInput.Text);

            if (response.IsSuccessStatusCode)
            {
                StartActivity(typeof(MainActivity));
            }
        }
        void BtnRegistration_Click(object sender, System.EventArgs e)
        {
            StartActivity(typeof(Registration));
        }
    }
}