using Logic.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Logic.Formatters;
using Data;
using System.Xml.Linq;

namespace Logic.XML
{
    public class saveXML
    {

        public static void removeFeed(string feed)
        {
            string location = loadPath.loadXmlPath();
            //XDocument doc = XDocument.Load(location);

            XElement el = XElement.Load(location);
            XElement delNode = el.Descendants("Feed").Where(a => a.Attribute("Name").Value == feed).FirstOrDefault();
            delNode.Remove();
            el.Save(location);
        }

        public static void editCategory(string name, int interval, string category, string originalName)
        {
            string location = loadPath.loadXmlPath();
            XElement el = XElement.Load(location);

            var target = el
                .Elements("Feed")
                .Where(e => e.Attribute("Name").Value == originalName)
                .Single();
            target.Attribute("Name").Value = name;
            target.Element("Interval").Value = interval.ToString();
            target.Element("Category").Value = category;
            el.Save(location);

        }



        public static void saveCategory(string cat)
        {

            Category category = new Category();
            Guid guid = Guid.NewGuid();
            category.Name = cat;
            category.Id = guid;

            var location = loadPath.loadCategoryPath();

                XmlDocument doc = new XmlDocument();
                doc.Load(location);
                XmlNode root = doc.DocumentElement;
                XmlElement catel = doc.CreateElement("CategoryItem");
                root.AppendChild(catel);
                XmlElement id = doc.CreateElement("Id");
                XmlElement name = doc.CreateElement("Name");
                id.InnerText = guid.ToString();
                name.InnerText = cat;
                catel.AppendChild(id);
                catel.AppendChild(name);
                doc.Save(location);
  
        }




        /// <summary>
        ///  Körs om inget feednamn anges när man blir tillsagt
        /// </summary>
        internal static void SaveXML(List<Feed> items)
        {

            var location = loadPath.loadXmlPath();

            if (!File.Exists(location))
            {
                using (var Stream = new FileStream(location, FileMode.Create))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(List<Feed>));
                    ser.Serialize(Stream, items);
                }
            }


            /// Körs om filen existerar
            else
            {

                XmlDocument doc = new XmlDocument();
                doc.Load(location);
                XmlNode root = doc.DocumentElement;

                foreach (var item in items)
                {
                    var idString = item.Id.ToString();
                    var nameString = item.Name.ToString();
                    var interval = item.Interval.ToString();
                    var category = item.Category.ToString();
                    var url = item.feedUrl.ToString();

                    XmlElement feed = doc.CreateElement("Feed");
                    feed.SetAttribute("Name", nameString);
                    root.AppendChild(feed);

                    XmlElement idNode = doc.CreateElement("Id");
                    XmlElement urlNode = doc.CreateElement("Url");
                    XmlElement intervalNode = doc.CreateElement("Interval");
                    XmlElement categoryNode = doc.CreateElement("Category");
                    XmlElement itemNode = doc.CreateElement("Items");


                    intervalNode.InnerText = interval;
                    categoryNode.InnerText = category;
                    idNode.InnerText = idString;
                    urlNode.InnerText = url;
                    //nameNode.InnerText = nameString;

                    feed.AppendChild(idNode);
                    //feed.AppendChild(nameNode);
                    feed.AppendChild(intervalNode);
                    feed.AppendChild(urlNode);
                    feed.AppendChild(categoryNode);
                    feed.AppendChild(itemNode);


                    foreach (var feeditems in item.Items)
                    {
                        var titleString = feeditems.title.ToString();
                        var dateString = feeditems.date.ToString();
                        var mediaString = feeditems.mediaUrl.ToString();
                        var listenedString = "No";

                        XmlElement title = doc.CreateElement("Title");
                        XmlElement date = doc.CreateElement("Date");
                        XmlElement media = doc.CreateElement("Media");
                        XmlElement feedItemNode = doc.CreateElement("FeedItem");
                        XmlElement listened = doc.CreateElement("Listened");


                        media.InnerText = mediaString;
                        title.InnerText = titleString;
                        date.InnerText = dateString;
                        listened.InnerText = listenedString;

                        feedItemNode.AppendChild(media);
                        feedItemNode.AppendChild(title);
                        feedItemNode.AppendChild(date);
                        feedItemNode.AppendChild(listened);
                        itemNode.AppendChild(feedItemNode);
                    }

                }

                doc.Save(location);
            }

        }
        
        public static void saveListened(string url) // Sparar att podden är lyssnad på.
        {
            //XmlDocument xml = new XmlDocument();
            var location = loadPath.loadXmlPath();
            var xml = XDocument.Load(location);

            var played = xml.Root
                            .Descendants("FeedItem")
                            .SingleOrDefault(e => (string)e.Element("Media") == url);

            if (played != null)
            {
                played.Element("Listened").Value = "Yes";
            }
            xml.Save(location);
                    
        }

    }
}