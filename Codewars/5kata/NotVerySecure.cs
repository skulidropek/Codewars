using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Codewars._5kata
{
	internal class NotVerySecure
	{
        public static bool Alphanumeric(string str) => str.Length > 0 && Regex.Replace(str, @"(\d|[a-z]|[A-Z])", "").Length == 0;
    }
}
