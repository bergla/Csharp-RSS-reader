using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class playMedia
    {

        /// <summary>
        ///  Denna klass formaterar endast urlen från listan om den ska spelas upp
        /// </summary>
        public static string playFile(string file)
        {

            string[] podCastItems = file.Split('='); //splittar för att få ut titeln och url separat
            var podCastUrl = podCastItems[4];
            if (podCastUrl.Contains(" "))
            {
                podCastUrl = podCastUrl.Replace(" ", string.Empty);

                if (podCastUrl.Contains("}"))
                {
                    podCastUrl = podCastUrl.Replace("}", string.Empty);
                }

            }

            return podCastUrl;
        }

        public static void playWMP(string url) // Spelar upp urlen i Windows Media Player
        {
           Process.Start("wmplayer.exe", url); 
            
        }

    }
}
