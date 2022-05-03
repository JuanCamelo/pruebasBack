using System.Text.RegularExpressions;

namespace AplicacionDigital.Services.Helpers
{
    public static class ValidationsRegex
    {
        public static bool WithRegEx(this string stringToVerify)
        {
            return Regex.IsMatch(stringToVerify, @"^[a-zA-Z\s]+$");
        }
        public static bool IsValidEmail(this string email)
        {
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        public static bool IsValidNumberPhone(this string number)
        {
            return Regex.Match(number, @"^(\+[0-9]{9})$").Success;
        }
    }
}
