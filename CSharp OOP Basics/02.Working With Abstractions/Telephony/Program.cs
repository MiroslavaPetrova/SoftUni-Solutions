using System;
using System.Collections.Generic;

namespace Telephony
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] numbersToCall = Console.ReadLine().Split();
            string[] websitesToBrowse = Console.ReadLine().Split();

            Smartphone smartPhone = new Smartphone();

            for (int i = 0; i < numbersToCall.Length; i++)
            {
                Console.WriteLine(smartPhone.Call(numbersToCall[i]));
            }

            for (int i = 0; i < websitesToBrowse.Length; i++)
            {
                Console.WriteLine(smartPhone.Browse(websitesToBrowse[i]));
            }
        }
    }
}
