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

        public IEnumerable<ITweet> GetListByTag(Label label, int lastSize)
        {

            Auth.SetUserCredentials(ConfigurationManager.AppSettings["consumerKey"],
                                     ConfigurationManager.AppSettings["consumerSecret"],
                                     ConfigurationManager.AppSettings["userAccessToken"],
                                     ConfigurationManager.AppSettings["userAccessSecret"]);

            Tweets = Search.SearchTweets(new SearchTweetsParameters("#drinkly")
            {
                MaximumNumberOfResults = 100,
            });

            var tweetsAmountNow = Tweets.ToList().Count;

            if (lastSize < tweetsAmountNow)
                MyEvent(label, "New tweet!!");
            else
                MyEvent(label, "No new tweets :(");
            
            return Tweets;
        }

    }
}
