﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMasterDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage() => InitializeComponent();

        private void Register_Clicked(object sender, EventArgs e)
        {
            DataService.getDataFromService();
           /* var client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

            var uri = new Uri("https://developer.xamarin.com/guides/xamarin-forms/cloud-services/consuming/rest/");

            var response = client.GetAsync(uri);

            var res = response.Result;

            var eeee = res.Content;*/

            //using (var client = new HttpClient())
            //{
            //    var user = new Dictionary<string, string>
            //        {
            //            { "UserName", "Tomas" },
            //            { "Password", "superPass" },
            //            { "ConfirmPassword", "superPass"}
            //        };


            //    var content = JsonConvert.SerializeObject(user);

            //    var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

            //    //content.Headers.ContentType = MediaTypeHeaderValue.Parse("Application/Json");

            //    var response = client.PostAsync("http://localhost:58376/api/Account/Register", httpContent).Result;
            //}


        


    }
    }
}
