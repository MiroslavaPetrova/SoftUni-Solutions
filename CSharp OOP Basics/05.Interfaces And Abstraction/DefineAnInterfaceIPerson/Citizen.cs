using System;

namespace PersonInfo
{
    public class Citizen : IPerson
    {
        private string name;
        private int age;

        public Citizen(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name
        {
            get => name;
            private set
            {
                if (value.Length < 5)
                {
                    throw new Exception("Name must be longer than 5 symbols!");
                }
                name = value;
            }
        }
        public int Age { get => age; set => age = value; }
    }
}
