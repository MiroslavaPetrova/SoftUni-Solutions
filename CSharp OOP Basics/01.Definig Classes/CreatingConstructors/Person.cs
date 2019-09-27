using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        private string name;
        private int age;

        public Person()
        {
            this.Name = "No name";
            this.Age = 1;
        }
        public Person(int age) : this()
        {
            this.age = age;
        }
        public Person(string name, int age) : this(age)
        {
            this.name = name;
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }
        public override string ToString()
        {
            return $"My name is {this.Name}. I am {this.Age} years old.";
        }
    }
}
