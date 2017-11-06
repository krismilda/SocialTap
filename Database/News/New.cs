using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.News
{
    public class New
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Username { get; set; }
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
