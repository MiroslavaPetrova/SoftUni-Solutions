﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Parent
    {
        public string Name { get; }
        public string BirthDate { get; }

        public Parent(string name, string birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }
    }
}
