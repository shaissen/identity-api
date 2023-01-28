using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pendulum.Identity.Service.Helpers
{
    public static class RegexHelper
    {
        public static bool IsEmail(this string email)
        {
            const string emailRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            return Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase);
        }

        public static bool IsPhone(this string phoneNumber)
        {
            const string phoneRegex = @"^(\+639)\d{9}$";
            return Regex.IsMatch(phoneNumber, phoneRegex, RegexOptions.IgnoreCase);
        }
    }
}
