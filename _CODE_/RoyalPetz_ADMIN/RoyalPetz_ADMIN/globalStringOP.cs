using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalPetz_ADMIN
{
    class globalStringOP
    {
        public string allTrim(string valueToTrim)
        {
            string temp = "";

            temp = valueToTrim.Replace(" ", "");

            return temp;
        }
    }
}
