﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    public class Pokemon
    {
        public string Name { get; }
        public string Element { get; }

        public Pokemon(string name, string element)
        {
            Name = name;
            Element = element;
        }
    }
}
