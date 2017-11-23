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


    [Activity(Label = "Activity1")]
    public class Activity1 : Activity
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
            // Autentification autentification = new Autentification();
            //   Boolean status=autentification.CheckLogin(emailInput.Text, passwordInput.Text);
            //   if (status)
            DataService.getDataFromService();
            {
              //  GetDataAsync();
            }
         //   else
            { 
          //      errorMessage.Text = "Wrong password or username";
            }
        }
        private async Task GetDataAsync()
        {
            var client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

            var uri = new Uri("http://drinklyapi20171122074316.azurewebsites.net/api/TopRestaurants");
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                 //   Restaurant r = new Restaurant();

                }
            }
            catch (Exception es)
            {
                string s = es.ToString();
            }
        }
        void BtnRegistration_Click(object sender, System.EventArgs e)
        {
            
        }
    }
}