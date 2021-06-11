using System;
using System.Collections.Generic;
using TwitterUCU;

namespace CompAndDel.Filters
{
    public class FilterTwitterPost : IFilter
    {
        public IPicture Filter(IPicture image)
        {   
            string consumerKey = "";
            string consumerKeySecret = "";
            string accessTokenSecret = "";
            string accessToken = "";
            var twitter = new TwitterImage(consumerKey, consumerKeySecret, accessToken, accessTokenSecret);
            Console.WriteLine(twitter.PublishToTwitter("text",@"../../Assets/FinalNewImage.jpg"));     
            return image;
        }
    }
}
