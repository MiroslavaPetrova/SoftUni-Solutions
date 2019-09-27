using System;
using System.Linq;

namespace Telephony
{
    public class SmartPhone : ICallable, IBrowsable
    {        
        public void Call(string phoneNumber)
        {
            if (!phoneNumber.All(Char.IsNumber))   
            {
                throw new ArgumentException("Invalid number!");
            }

            Console.WriteLine($"Calling... {phoneNumber}");
        }

        public void Browse(string site)
        {
            if (site.Any(Char.IsNumber))
            {
                throw new ArgumentException("Invalid URL!");
            }
            Console.WriteLine($"Browsing: {site}!");
        }
    }
}
