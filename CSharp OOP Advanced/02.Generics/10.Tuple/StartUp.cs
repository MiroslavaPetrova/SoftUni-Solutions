namespace Tuple
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split();
            string fullName = personInfo[0] + " " + personInfo[1];
            string address = personInfo[2];

            string[] drinkingAbility = Console.ReadLine().Split();
            string name = drinkingAbility[0];
            int beers = int.Parse(drinkingAbility[1]);

            string[] inputNumbers = Console.ReadLine().Split();
            int firstNumber = int.Parse(inputNumbers[0]);
            double secondNumber = double.Parse(inputNumbers[1]);



            CustomTuple<string, string> personTuple = new CustomTuple<string, string>(fullName, address);
            CustomTuple<string, int> beerTuple = new CustomTuple<string, int>(name, beers);
            CustomTuple<int, double> numbersTuple = new CustomTuple<int, double>(firstNumber, secondNumber);

            Console.WriteLine(personTuple);
            Console.WriteLine(beerTuple);
            Console.WriteLine(numbersTuple);
        }
    }
}
