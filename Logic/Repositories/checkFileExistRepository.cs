using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public class checkFileExistRepository
    {

        public static bool checkFileExist(string fileName)
        {
            checkFileExist checkfile = new checkFileExist();
            
            return checkfile.doesExist(fileName);
        }

    }
}
