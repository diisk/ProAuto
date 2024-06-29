using System.Text.RegularExpressions;

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