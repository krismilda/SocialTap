using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi.Models;

namespace Services.TwitterAPI
{
    class ListByTag
    {
        public ListByTag()
        {        
            TwitterCredentials.SetCredentials("Access_Token", "Access_Token_Secret", "Consumer_Key", "Consumer_Secret");
        }
    }
}
