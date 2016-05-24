using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Logic.Validators
{
    public class validateURL
    {

        public static bool checkURL(string url)
        {
            bool valid;
            Regex r = new Regex(@"(?<Protocol>\w+):\/\/(?<Domain>[\w@][\w.:@]+)\/?[\w\.?=%&=\-@/$,]*");

            if (url != null && url != "" && r.IsMatch(url))
            {
                //försöker att läsa ett item i feeden, om urlen ej är rss feed så kommer detta resultera till att valid är falskt
                try
                {
                    XmlReader reader = XmlReader.Create(url);
                    Rss20FeedFormatter formatter = new Rss20FeedFormatter();
                    formatter.ReadFrom(reader);
                    reader.Close();
                    valid = true;
                }
                catch
                {
                    valid = false;
                }


            }
            else
            {
                valid = false;
            }

            return valid;
        }

    }
}
