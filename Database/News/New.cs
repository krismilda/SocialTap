using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.News
{
    public class New
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }

        public New() { }
        public New(string username, string message)
        {
            Date = DateTime.Today;
            Username = username;
            Message = message;
        }
    }

}
