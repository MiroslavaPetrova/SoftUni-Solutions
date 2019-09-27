using System;
using System.Collections.Generic;

namespace Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();

            SmartPhone smartPhone = new SmartPhone();

            foreach (var number in phoneNumbers)
            {
                try
                {
                    smartPhone.Call(number);

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            foreach (var site in sites)
            {
                try
                {
                    smartPhone.Browse(site);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }  
    }
}
