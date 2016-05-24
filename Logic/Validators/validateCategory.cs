using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logic.Validators
{
    public class validateCategory
    {
        public static bool checkCategory(string category)
        {
            Regex r = new Regex(@"^[a-zA-Z]+$");

            if (category != null && category.Length > 0 && r.IsMatch(category))
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
