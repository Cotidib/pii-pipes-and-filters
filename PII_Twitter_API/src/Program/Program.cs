using System;

namespace TwitterUCU
{
    class Program
    {
        static void Main(string[] args)
        {
            string consumerKey = "";
            string consumerKeySecret = "";
            string accessTokenSecret = "";
            string accessToken = "1396065818-";
            var twitter = new TwitterImage(consumerKey, consumerKeySecret, accessToken, accessTokenSecret);
            Console.WriteLine(twitter.PublishToTwitter("New Employee 2! ",@"bill2.jpg"));
            var twitterDirectMessage = new TwitterMessage(consumerKey, consumerKeySecret, accessToken, accessTokenSecret);
            Console.WriteLine(twitterDirectMessage.SendMessage("Hola!", "380889967"));
        }
    }
}
