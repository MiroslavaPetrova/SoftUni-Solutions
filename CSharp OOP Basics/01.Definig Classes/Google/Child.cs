using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Child
    {
        public string Name { get; }
        public string BirthDate { get; }

        public Child(string name, string birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }
    }
}
