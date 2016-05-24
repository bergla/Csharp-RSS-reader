using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Data
{
    public class loadPath
    {

        public static string loadDownloadPath()
        {                                   // hämtar vägen där projektet ligger i                                                                     // namnet på settingsfilen
            var projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\GlobalSettings.super";

            using (FileStream stream = new FileStream(projectDir, FileMode.Open))
            {
                // deserialiserar filen och retrunerar sökvägen
                var ser = new XmlSerializer(typeof(string));
                return (string)ser.Deserialize(stream);
            }
        }

        public static string loadXmlPath()
        {
            string location = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\feedList.xml";
            return location;
        }


        public static string loadCategoryPath()
        {
            string location = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\categories.xml";
            return location;
        }

    }
}
