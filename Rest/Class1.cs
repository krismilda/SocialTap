using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest
{
    public class Rest
    {
        public void Call() {
            var client = new RestClient("http://localhost:58376/api/TopRestaurants");
            var request = new RestRequest("", Method.GET);
            var response = client.Execute(request);
        }

    }
}
