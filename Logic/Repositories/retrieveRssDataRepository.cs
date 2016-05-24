using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Logic.Entities;
using Logic.Exceptions;

namespace Logic.Repositories
{
    public class retrieveRssDataRepository
    {

        /// <summary>
        ///  Denna funktion hämtar information om feednamnet och en url till själva feedbilden
        /// </summary>
        public virtual string[] catchInfo(string url)
        {
            string[] info = new string[2];   // här läggs titel på feeden samt url för bilen in

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(url);
            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("channel/image");  //anger root directory, vilka noder den ska gå in i  

            foreach (XmlNode node in nodes)
            {   //för varje nod

                try
                {
                    info[0] = node["title"].InnerText.ToString(); //hämtar titel från title-noden
                    info[1] = node["url"].InnerText.ToString(); //hämtar url från urlnoden
                }
                catch(ValidationException ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }

            return info;
        }







        /// <summary>
        /// Denna funktion hämtar data från urlen
        /// som skickas in form av en string
        /// </summary>
        /// <param name="url"></param>
        /// <returns>en lista av podCastFeedListItem</returns>
        public List<Logic.Entities.FeedItem> retrieveData(string url)
        {

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(url);
            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("channel/item");  //anger root directory, vilka noder den ska gå in i

            List<Logic.Entities.FeedItem> rssCollection = new List<Logic.Entities.FeedItem>();  //skapar en lista i form av podcastfeedlistitem

            foreach (XmlNode node in nodes)
            {   //för varje nod

                try
                {
                    string MediaUrl = node["enclosure"].Attributes["url"].Value; // hämtar value för url attributen i enclosure-taggen
                    string Title = node["title"].InnerText.ToString(); //hämtar titel från title-noden
                    string Date = node["pubDate"].InnerText.ToString();

                    // skapar ett item i form av podCastFeedListItem och anger värdena
                    var item = new Logic.Entities.FeedItem
                    {
                        mediaUrl = MediaUrl,
                        title = Title,
                        date = Date
                    };

                    rssCollection.Add(item);     // lägger till objekt

                }
                catch
                {

                }
            }

            return rssCollection;
        }

    }
}
