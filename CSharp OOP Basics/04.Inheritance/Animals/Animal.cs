using System;

namespace Animals
{
    public class Animal
    {
        private string animalType;
        private string name;
        private int age;
        private string gender;

        protected Animal(string animalType,string name, int age, string gender)
        {
            this.AnimalType = animalType;
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new FormatException("Invalid input!");
                }
                name = value;
            }
        }
        public int Age  
        {
            get => age;
            private set
            {
                if (value <= 0)    
                {
                    throw new FormatException("Invalid input!");
                }
                age = value;
            }
        }
        public string Gender
        {
            get => gender;
            protected set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new FormatException("Invalid input!");
                }
                gender = value;
            }
        }

        public string AnimalType
        {
            get => animalType;
            private set
            {
                animalType = value;
            }
        }

        public string Sound
        {
            get => ProduceSound();
        }

        private string ProduceSound()
        {
            string sound = string.Empty;
            switch (this.AnimalType.ToLower())
            {
                case "dog":
                    sound = "Woof!";
                    break;
                case "cat":
                    sound = "Meow meow";
                    break;
                case "frog":
                    sound = "Ribbit";
                    break;
                case "kitten":
                    sound = "Meow";
                    break;
                case "tomcat":
                    sound = "MEOW";
                    break;
            }
            return sound; 
        }
        // todo: check value.ToLower();

        //public override string ToString()
        //{
        //    return $"{this.Name} {this.Age} {this.Gender}";
        //}
    }
}
