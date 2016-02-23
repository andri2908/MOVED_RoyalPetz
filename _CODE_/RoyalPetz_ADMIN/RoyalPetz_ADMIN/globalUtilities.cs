using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace RoyalPetz_ADMIN
{
    class globalUtilities
    {
        public const string REGEX_NUMBER_WITH_2_DECIMAL = @"^[0-9]*\.?\d{0,2}$";
        public const string REGEX_NUMBER_ONLY = @"^[0-9]*$";

        public string allTrim(string valueToTrim)
        {
            string temp = "";

            temp = valueToTrim.Replace(" ", "");

            return temp;
        }

        public bool matchRegEx(string textToMatch, string regExValue)
        {
            Regex r = new Regex(regExValue); // This is the main part, can be altered to match any desired form or limitations
            Match m = r.Match(textToMatch);

            return m.Success;
        }


    }
}
