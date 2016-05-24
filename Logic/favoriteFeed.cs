using Logic.Entities;
using Logic.XML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class favoriteFeed
    {

        // ----------------- Funktionerna i denna klass använder sig av method overloading --------------------//


        public static void saveFeed(List<FeedItem> podItem, int interval, string category, string feedUrl)
        {
            List<Feed> feedList = new List<Feed>();
            Guid id = Guid.NewGuid(); // skapar ett 128-bitars guid id 
            feedList.Add(new Feed { Id = id, Name = id.ToString(), Items = podItem, Interval = interval, Category = category, feedUrl = feedUrl });   // lägger till ett id, ett namn , samt alla de items som finns i feeden som en lista av feeditem

            saveXML.SaveXML(feedList);
        }

        /// <summary>
        ///  Körs om namn anges
        /// </summary>
        public static void saveFeed(List<FeedItem> podItem, string feedName, int interval, string category, string feedUrl)
        {
            List<Feed> feedList = new List<Feed>();
            Guid id = Guid.NewGuid(); // skapar ett 128-bitars guid id 
            feedList.Add(new Feed { Id = id, Name = feedName, Items = podItem, Interval = interval, Category = category, feedUrl = feedUrl });   // lägger till ett id, ett namn , samt alla de items som finns i feeden som en lista av feeditem

            saveXML.SaveXML(feedList);
        }

    }
}
