using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.Entities;
using System.Xml;
using Data;
using System.Xml.Linq;

namespace Logic.XML
{
    public class loadXML
    {

        public static List<String> getFeed()
        {
            string location = loadPath.loadXmlPath();
            List<String> feed = new List<String>();

            XmlDocument doc = new XmlDocument();
            doc.Load(location);

            XmlNodeList xmlList = doc.SelectNodes("ArrayOfFeed/Feed");
            string name;
            foreach (XmlNode item in xmlList)
            {
                try
                {
                    name = item.Attributes["Name"].Value;
                    feed.Add(name);
                }
                catch { }
            }

            return feed;
        }

        public static List<String> addCatToCb()
        {
            string location = loadPath.loadCategoryPath();
            List<String> catItems = new List<String>();
            XmlDocument doc = new XmlDocument();
            doc.Load(location);

            XmlNodeList xmlList = doc.SelectNodes("Category/CategoryItem");
            string cat;
            foreach (XmlNode item in xmlList)
            {
                cat = item["Name"].InnerText.ToString();
                catItems.Add(cat);
            }
            return catItems;

        }



        /// <summary>
        /// FORTSÄTT HÄR!!!
        /// </summary>
        /// <param name="feedName"></param>
        /// <returns></returns>
        public static List<FeedItem> loadLocalFeed(string feedName)
        {
            string location = loadPath.loadXmlPath();

            XDocument doc = XDocument.Load(location);

            IEnumerable<FeedItem> result =
             doc.Descendants("Feed")
                .Where(c => c.Attribute("Name").Value == feedName)
                .Descendants("FeedItem")
                .Select(z => new FeedItem
                {
                    title = (string)z.Element("Title"),
                    date = (string)z.Element("Date"),
                    mediaUrl = (string)z.Element("Media"),
                })
            .ToList(); 

            return result.Cast<FeedItem>().ToList();
        }

        public static string loadLocalFeedUrl(string Feedname)
        {
            string location = loadPath.loadXmlPath();
            XDocument doc = XDocument.Load(location);

            var result = from c in doc.Descendants("Feed")
                         where c.Attribute("Name").Value == Feedname
                         select new
                         {
                             c.Element("Url").Value
                         };
            return result.Single().Value.ToString();
        }

        public static List<String> loadLocalCategoryFeed(string category)
        {
            string location = loadPath.loadXmlPath();
            XDocument doc = XDocument.Load(location);
            var result = doc.Descendants("Feed")
                .Where(x => (string)x.Element("Category") == category)
                .Select(z => (string)z.Attribute("Name")).ToList();
            return result;
        }

        public static string loadLocalFeedInteval(string Feedname)
        {
            string location = loadPath.loadXmlPath();
            XDocument doc = XDocument.Load(location);

            var result = from c in doc.Descendants("Feed")
                         where c.Attribute("Name").Value == Feedname
                         select new
                         {
                             c.Element("Interval").Value
                         };
            return result.Single().Value.ToString();
        }

    }
}
