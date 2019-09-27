﻿namespace BirthdayCelebrations
{
    public class Citizen : IBirthable, IIdentifiable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Name { get; }
        public int Age { get; }
        public string Id {get;}
        public string Birthdate { get; }

    }
}
