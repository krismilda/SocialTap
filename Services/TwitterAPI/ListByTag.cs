using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tweetinvi;
using Tweetinvi.Core.Extensions;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace Services.TwitterAPI
{
    public class ListByTag
    {
        public IEnumerable<ITweet> Tweets { get; set; }

        public event Action<Label, string> MyEvent;

        private void MyEventHandler(Label l, string text)
        {
            l.Text = text;  
        }

        public ListByTag() 
        {
            MyEvent += new Action<Label, string>(MyEventHandler);
        }

        public IEnumerable<ITweet> GetListByTag()
        {
                        Auth.SetUserCredentials("MCFAVXP8HAiIPc9NVaHgnHn5x",
                                     "NsJxyblOmm6UXfGq1yBTGUE1e2IREcu2OL98pJG4y4N1zWwGEl",
                                     "932271865191682049-oyEYeq9bOLm8L2GLSXeZRTUYKs8CFHx",
                                     "pvryBwdzpdkSc9yNMgJwC7B8J4AEXWQkU0EC3LWaKpTJ2");

            Tweets = Search.SearchTweets(new SearchTweetsParameters("#drinkly")
            {
                MaximumNumberOfResults = 100,
            });

            var tweetsAmountNow = Tweets.ToList().Count;
      

           
           /* if (lastSize < tweetsAmountNow)
                MyEvent(label, "New tweet!!");
            else
                MyEvent(label, "No new tweets :(");
            */
            return Tweets;
        }

    }
}
