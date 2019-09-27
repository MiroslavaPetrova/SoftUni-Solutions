using System;
namespace Animals
{
    public class Kitten : Animal
    {
        public Kitten(string animalType, string name, int age, string gender) 
            : base(animalType, name, age, gender)
        {
            this.Gender = "Female";
        }
    }
}
