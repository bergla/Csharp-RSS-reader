using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class checkFileExist
    {

        public bool doesExist(string fileName)
        {

            var pathInfo = loadPath.loadDownloadPath() + "\\" + fileName + ".mp3";
            pathInfo = pathInfo.Replace("\\", "//");

            if (File.Exists(pathInfo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
