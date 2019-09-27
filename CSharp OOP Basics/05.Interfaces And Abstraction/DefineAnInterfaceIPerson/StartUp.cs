using System;
namespace PersonInfo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();    // myTrial not as expected in the Lab
            int age = int.Parse(Console.ReadLine());
            try
            {
                IPerson person = new Citizen(name, age);
                Console.WriteLine(person.Name);
                Console.WriteLine(person.Age);
            }
            catch (Exception ae)
            {

                Console.WriteLine(ae.Message);
            }
            
        }
    }
}
