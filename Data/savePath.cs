using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Data
{
   public  class savePath
    {

       public static void saveDownloadPath(string path)
       {

           var projectDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\GlobalSettings.super";

           using (var stream = new FileStream(projectDir, FileMode.Create))
           {

               XmlSerializer ser = new XmlSerializer(typeof(string));
               ser.Serialize(stream, path);
           }

       }

    }
}
