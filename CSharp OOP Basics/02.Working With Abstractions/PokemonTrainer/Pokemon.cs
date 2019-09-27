using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Pokemon
    {
        //name, an element and health, all values are mandatory. Every Trainer starts with 0 badges.
        public Pokemon(string name, string element, int health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }

        public string Name { get; set; }

        public string Element { get; set; }

        public int Health { get; set; }
    }
}
