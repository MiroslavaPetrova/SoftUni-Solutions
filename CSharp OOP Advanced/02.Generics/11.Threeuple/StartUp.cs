namespace Threeuple
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split();

            string fullName = personInfo[0] + " " + personInfo[1];
            string quarters = personInfo[2];
            string town = personInfo[3];

            string[] drinkingAbility = Console.ReadLine().Split();

            string name = drinkingAbility[0];
            int beers = int.Parse(drinkingAbility[1]);
            bool isDrunk = drinkingAbility[2] == "drunk" ? true : false;

            string[] bankInfo = Console.ReadLine().Split();

            string personName = bankInfo[0];
            double accountBalance = double.Parse(bankInfo[1]);
            string bankName = bankInfo[2];



            CustomTuple<string, string, string> personTuple = new CustomTuple<string, string, string>
                (fullName, quarters, town);
            CustomTuple<string, int, bool> beerTuple = new CustomTuple<string, int, bool>
                (name, beers, isDrunk);
            CustomTuple<string, double, string> bankTuple = new CustomTuple<string, double, string>
                (personName, accountBalance, bankName);

            Console.WriteLine(personTuple);
            Console.WriteLine(beerTuple);
            Console.WriteLine(bankTuple);
        }
    }
}
