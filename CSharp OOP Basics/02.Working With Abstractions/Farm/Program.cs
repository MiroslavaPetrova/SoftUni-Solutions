using Farm.Core;
using System;

namespace Farm
{
   public class Program
    {
        public static void Main(string[] args)
        {
            //todo debug ToString()
            // how are Tomcats & Kittens created => Cat => base Animal.cs ctors
            // what if gender is missing in the input ?
            //default: throw new ArgumentException("Invalid input!");
            // ALL DONE!
            Engine engine = new Engine();
            engine.Run();
        }
    }
}
