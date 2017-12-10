
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Newtonsoft.Json;
using AndroidApp.Models;
using System.Collections.Specialized;

using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;
using Android.Content;
using Android.App;
using Android.Net;
using AndroidApp.Models;


namespace AndroidApp
{
    public static class DataService
    {
        private static string _userToken;
        private static ISharedPreferences _storageReference;
        private static HttpClient _client;
        public static bool ShowNotification;
        public static bool MuteNotification;

        static DataService()
        {

            _client = new HttpClient(); // { BaseAddress = new System.Uri("http://drinkly1.azurewebsites.net/api/") };
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _userToken);
        }

        public static async Task<HttpResponseMessage> Register(string username, string password, string confirmPassword)
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
                return response;
            }
        }

        public static async Task<HttpResponseMessage> Login(string username, string password)
        {
            using (HttpClient client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, "http://drinkly1.azurewebsites.net/api/Account/Login"))
            {
                var headerValues = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password)
                };
                request.Content = new FormUrlEncodedContent(headerValues);

                var res = client.SendAsync(request).Result;
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    _userToken = JsonConvert.DeserializeObject<string>(responseContent);
                    _storageReference = Application.Context.GetSharedPreferences("Token", FileCreationMode.Private);
                    var editor = _storageReference.Edit();
                    editor.PutString("UserToken", _userToken);
                    editor.Apply();
                }
                return response;
            }
        }

        public static async Task AddNew(string text)
        {

            using (HttpClient client = new HttpClient())
            {
                var newsJson = new Dictionary<string, string>
                    {
                        { "Date", DateTime.Today.ToString()},
                        { "Text", text}
                   };
                var content = JsonConvert.SerializeObject(newsJson);
                var httpContent = new StringContent(content, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://drinkly1.azurewebsites.net/api/News", httpContent);
            }
        }
        public static async Task<List<News>> GetNewsList()
        {

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.MaxResponseContentBufferSize = 256000;

                    var uri = new System.Uri("http://drinkly1.azurewebsites.net/api/News");

                    var response = await client.GetAsync(uri);

                    var resultObject = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<News>>(resultObject);
                    return data;
                }
                catch (Exception e)
                {
                    string s = e.ToString();
                }
            }
            return null;
        }
        public static async Task<List<Tweet>> GetTweetList()
        {

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.MaxResponseContentBufferSize = 256000;

                    var uri = new System.Uri("http://drinkly1.azurewebsites.net/api/Tweet");

                    var response = await client.GetAsync(uri);

                    var resultObject = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<Tweet>>(resultObject);
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
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.MaxResponseContentBufferSize = 256000;

                    var uri = new System.Uri("http://drinkly1.azurewebsites.net/api/Restaurant");

                    var response = await client.GetAsync(uri);
                    string json = response.Content.ReadAsStringAsync().Result;
                    //   var data = JsonConvert.DeserializeObject<Restaurant>(json);
                }
            }
            catch (Exception e)
            {
                string s = e.ToString();
            }
            return null;
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
        public static async Task<List<Restaurant>> GetTopRestaurant(string period)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.MaxResponseContentBufferSize = 256000;

                    var uri = new System.Uri("http://drinkly1.azurewebsites.net/api/TopRestaurants/?duration=" + period);

                    var response = await client.GetAsync(uri);

                    var resultObject = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<Restaurant>>(resultObject);
                    return data;
                }
                catch (Exception e)
                {
                    string s = e.ToString();
                }
                return null;
            }
        }
        public static async Task<List<Restaurant>> GetMostVisited(string period)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.MaxResponseContentBufferSize = 256000;


                    var uri = new System.Uri("http://drinkly1.azurewebsites.net/api/MostVisited/?duration=" + period);

                    var response = await client.GetAsync(uri);

                    var resultObject = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<Restaurant>>(resultObject);
                    return data;
                }
                catch (Exception e)
                {
                    string s = e.ToString();
                }
                return null;
            }
        }
        public static async Task<List<Restaurant>> GetTopDrinks(string period)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.MaxResponseContentBufferSize = 256000;

                    var uri = new System.Uri("http://drinkly1.azurewebsites.net/api/TopDrinks/?duration=" + period);


                    var response = await client.GetAsync(uri);

                    var resultObject = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<Restaurant>>(resultObject);
                    return data;
                }
                catch (Exception e)
                {
                    string s = e.ToString();
                }
                return null;
            }
        }
        public static async Task<Moneys> GetMoneyCommon(string period)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.MaxResponseContentBufferSize = 256000;

                    var uri = new System.Uri("http://drinkly1.azurewebsites.net/api/MoneyHistory/GetCommon/?duration=" + period);


                    var response = await client.GetAsync(uri);

                    var resultObject = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<Moneys>(resultObject);
                    return data;
                }
                catch (Exception e)
                {
                    string s = e.ToString();
                }
                return null;
            }
        }
        public static async Task<List<Moneys>> GetMoneyDrink(string period)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.MaxResponseContentBufferSize = 256000;

                    var uri = new System.Uri("http://drinkly1.azurewebsites.net/api/MoneyHistoryDrink/GetDrink/?duration=" + period);


                    var response = await client.GetAsync(uri);

                    var resultObject = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<Moneys>>(resultObject);
                    return data;
                }
                catch (Exception e)
                {
                    string s = e.ToString();
                }
                return null;
            }
        }
        public static async Task<int?> Upload(byte[] image)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    using (var content = new MultipartFormDataContent("Upload----"))
                    {
                        var imgStream = new MemoryStream(image);
                        var streamContent = new StreamContent(imgStream);
                        var imageContent = new ByteArrayContent(streamContent.ReadAsByteArrayAsync().Result);
                        imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

                        content.Add(imageContent, "image");
                    
                        using (var message = await client.PostAsync("http://drinkly1.azurewebsites.net/api/ImageProcessing", content))
                        {
                            var input = await message.Content.ReadAsStringAsync();

                            return JsonConvert.DeserializeObject<int>(input);
                        }
                    }
                }
                catch(Exception e)
                {
                    string s = e.ToString();
                }

            }
            return null;
        }


        public static void GetUserToken()
        {
            _storageReference = Application.Context.GetSharedPreferences("Token", FileCreationMode.Private);
            _userToken = _storageReference.GetString("UserToken", null);
            ShowNotification = _storageReference.GetBoolean("Notification", false);
            MuteNotification = _storageReference.GetBoolean("NotificationMute", false);
        }

        public static async Task<double> GetBMI(int weight, int height)
        {

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    client.MaxResponseContentBufferSize = 256000;
                   
                    var uri = new System.Uri("http://drinkly1.azurewebsites.net/api/BMI" + "?" +"Weight=" + weight + "&" + "Height=" + height);
                    //var values = new Dictionary<string, int> { { "Weight", weight },
                    //                                           { "Height", height }
                    //                                         };
                    //var result = ur.ExtendQuery(values);
                    var response = await client.PutAsync(uri, null);

                    var resultObject = await response.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<double>(resultObject);
                    return data;
                }
                catch (Exception e)
                {
                    string s = e.ToString();
                }
            }
            return 0;
        }

    }

}