using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
          
        }

        public static string BetKas()
        {
            using (var client = new HttpClient())
            {
                var user = new Dictionary<string, string>
                    {
                        { "UserName", "Tomas" },
                        { "Password", "superPass" },
                        { "ConfirmPassword", "superPass"}
                    };


                var content = JsonConvert.SerializeObject(user);

                var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

                //content.Headers.ContentType = MediaTypeHeaderValue.Parse("Application/Json");

                var response = client.PostAsync("http://localhost:58376/api/Account/Register", httpContent).Result;

                return response.ToString();
            }
        }


    }
}
