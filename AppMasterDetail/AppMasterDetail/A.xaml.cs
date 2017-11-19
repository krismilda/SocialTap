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
    public partial class A : ContentPage
    {
        public A()
        {
            InitializeComponent();
        }

        private async void Register_Clicked(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                var user = new Dictionary<string, string>
                    {
                        { "userName", usernameEntry.Text },
                        { "password", passwordEntry.Text },
                        { "confirmPassword", passwordConfirmEntry.Text}
                    };

                var content = new FormUrlEncodedContent(user);

                content.Headers.Add("Content-Type", "Application/Json");

                var response = await client.PostAsync("http://localhost:58376/api/Account/Register", content);

                var responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Registration", "Success!", "Ok");
                }
               
                
            } 

        }
    }
}