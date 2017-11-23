using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace AppMasterDetail
{
    public static class DataService
    {
        public static async Task Login(string username, string password, string confirmPassword)
        {
            using(HttpClient client = new HttpClient())
            {
                var user = new Dictionary<string, string>
                   {
                       { "UserName", username },
                       { "Password", password },
                       { "ConfirmPassword", confirmPassword}
                  };
                var content = JsonConvert.SerializeObject(user);
                var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
                var response = client.PostAsync("http://localhost:58376/api/Account/Register", httpContent).Result;
                int a = 5;
            }
        }

        public static async Task <Restaurant> GetTweetList ()
        {
            using (HttpClient client = new HttpClient())
            {
                client.MaxResponseContentBufferSize = 256000;

                var uri = new Uri("http://localhost:58376/api/Tweet");

                var response = await client.GetAsync(uri);
                string json = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Restaurant>(json);
                return data;
            }
        }

        public static async Task<Restaurant> GetRestaurant()
        {
            using(HttpClient client = new HttpClient())
            {
                client.MaxResponseContentBufferSize = 256000;

                var uri = new Uri("http://drinklyapi20171122074316.azurewebsites.net/api/TopRestaurants");

                var response = await client.GetAsync(uri);
                string json = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Restaurant>(json);
                return data;
            }
        }

    }
}
