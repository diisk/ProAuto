using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProAuto.Helpers
{
    public class Utils
    {
        public static String ApenasNumeros(String value)
        {
            Regex regex = new Regex(@"\D");
            return regex.Replace(value, "");
        }
    }
}