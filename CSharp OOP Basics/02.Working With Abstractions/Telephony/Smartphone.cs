using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowseable
    {
        public string Browse(string website)
        {
            if (website.Any(c => char.IsDigit(c)))
            {
                return $"Invalid URL!";
            }
            else
            {
                return ($"Browsing: {website}!");
            }
        }

        public string Call(string number)
        {
            if (number.All(n => char.IsDigit(n)))
            {
                return ($"Calling... {number}");
            }
            else
            {
                return $"Invalid number!";
            }
        }
    }
}
