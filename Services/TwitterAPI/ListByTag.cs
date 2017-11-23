using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Core.Extensions;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace Services.TwitterAPI
{
    public class ListByTag
    {
        public IEnumerable<ITweet> Tweets { get; set; }

        public ListByTag()
        {
            Auth.SetUserCredentials(ConfigurationManager.AppSettings["consumerKey"],
                                     ConfigurationManager.AppSettings["consumerSecret"],
                                     ConfigurationManager.AppSettings["userAccessToken"],
                                     ConfigurationManager.AppSettings["userAccessSecret"]);
             
            Tweets = Search.SearchTweets(new SearchTweetsParameters("#drinkly")
            {
                MaximumNumberOfResults = 100,
            });
        }

    }
}
