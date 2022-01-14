using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanBookDB_ASPNET_MVC_Web_BLL
{
    public static class SiteSettings
    {
        public static string CharacterFormatConverter(string value)
        {
            string result = value.ToLower();
            result = result.Replace("'", "");
            result = result.Replace(" ", "-");
            result = result.Replace("<", "");
            result = result.Replace(">", "");
            result = result.Replace("&", "");
            result = result.Replace("[", "");
            result = result.Replace("!", "");
            result = result.Replace("]", "");
            result = result.Replace("ı", "i");
            result = result.Replace("ö", "o");
            result = result.Replace("ü", "u");
            result = result.Replace("ş", "s");
            result = result.Replace("ç", "c");
            result = result.Replace("ğ", "g");
            result = result.Replace("İ", "I");
            result = result.Replace("Ö", "O");
            result = result.Replace("Ü", "U");
            result = result.Replace("Ş", "S");
            result = result.Replace("Ç", "C");
            result = result.Replace("Ğ", "G");
            result = result.Replace("|", "");
            result = result.Replace(".", "-");
            result = result.Replace("?", "-");
            result = result.Replace(";", "-");

            return result;
        }


    }
}
