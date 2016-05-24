using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Repositories
{
    public class downloadFilesRepository
    {



        /// <summary>
        /// laddar ner en podcast, url skickas som parameter
        /// </summary>
        public static void downloadPod(string url) 
        {

            var downloadPath = loadPath.loadDownloadPath(); // hämtar nerladdningsvägen
            downloadPodCast.downloadPod(url);  // laddar ner url, denna klass "downloadPodCast" ligger i datalagret

        }

    }
}
