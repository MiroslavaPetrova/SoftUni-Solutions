using System;

namespace Cars
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Seat seat = new Seat("Grey", "Leon");
            Tesla tesla = new Tesla("Red", "Model 3", 2);
           
            Console.WriteLine(seat);
            Console.WriteLine(seat.Start());
            Console.WriteLine(seat.Stop());

            Console.WriteLine(tesla);
            Console.WriteLine(tesla.Start());
            Console.WriteLine(tesla.Stop());
            

        }
    }
}
