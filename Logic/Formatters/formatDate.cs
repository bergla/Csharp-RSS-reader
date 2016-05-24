using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Formatters
{
    public class formatDate
    {

        public static string FormatDate(string date)
        {

            var dateFormat = date.Split(' ');
            date = dateFormat[0] + " " + dateFormat[1] + ", " + dateFormat[2] + " " + dateFormat[3];

            return date;
        }

    }
}
