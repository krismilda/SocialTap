﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace AppMasterDetail
{
    public static class DataService
    {
        public static async Task Register(string username, string password, string confirmPassword)
        {
            using (HttpClient client = new HttpClient())
            {
                var user = new Dictionary<string, string>
                   {
                       { "UserName", username },
                       { "Password", password },
                       { "ConfirmPassword", confirmPassword}
                  };
                var content = JsonConvert.SerializeObject(user);
                var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://drinkly1.azurewebsites.net/api/Account/Register", httpContent);

            }
        }

        public static async Task<List<Tweet>> GetTweetList()
        {

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.MaxResponseContentBufferSize = 256000;

                    var uri = new Uri("http://drinkly1.azurewebsites.net/api/Tweet");

                    var response = await client.GetAsync(uri);
                    string json = response.Content.ReadAsStringAsync().Result;
                    var data = JsonConvert.DeserializeObject<List<Tweet>>(json);
                    return data;
                }
                catch (Exception e)
                {
                    string s = e.ToString();
                }
            }
            return null;
        }

        public static async Task<Restaurant> GetRestaurant()
        {
            using (HttpClient client = new HttpClient())
            {
                client.MaxResponseContentBufferSize = 256000;

                var uri = new Uri("http://drinklyapi20171122074316.azurewebsites.net/api/TopRestaurants");

                var response = await client.GetAsync(uri);
                string json = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<Restaurant>(json);
                return data;
            }
        }

        public static async Task SearchRestaurant()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                if (locator.IsGeolocationEnabled)
                {
                    var position = await locator.GetPositionAsync();
                    position.ToString();
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Geolocation is disabled!");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Unable to get location, may need to increase timeout: " + ex);
            }
        }

    }
}
