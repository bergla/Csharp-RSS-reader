using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class downloadPodCast
    {

        /// <summary>
        ///  laddar ner markerad podcast
        /// </summary>
        public static void downloadPod(string podcast)
        {


            //formatering för podcast stringen som skickas in, endast för att få ut en korrekt url till mediafilen
            string[] podCastItems = podcast.Split('='); //splittar för att få ut titeln och url separat
            var podCastUrl = podCastItems[4];
            if (podCastUrl.Contains(" "))
            {
                podCastUrl = podCastUrl.Replace(" ", string.Empty);

                if (podCastUrl.Contains("}"))
                {
                    podCastUrl = podCastUrl.Replace("}", string.Empty);
                }

            }




            string podCastFileName = podCastItems[1];
            podCastFileName = podCastFileName.Trim();
            podCastFileName = podCastFileName.Replace(", Date", string.Empty);

            if (podCastUrl.Contains(".mp3") || podCastUrl.Contains(".ogg") || podCastUrl.Contains(".wav") || podCastUrl.Contains(".m4a") || podCastUrl.Contains(".wma") || podCastUrl.Contains(".aiff")) //kollar om länken innehåller korrekta musikformat
            {
                var location = loadPath.loadDownloadPath() + '\\' + podCastFileName + ".mp3";   // laddar location för där filen ska sparas

                WebClient client = new WebClient();
                client.DownloadFileAsync(new Uri(podCastUrl), location);  // laddar ner filen async
            }
        }

    }
}
