using System.Collections.Generic;

namespace PokemonTrainer
{
    public class Trainer
    {
        //name, number of badges and a collection of pokemon, Every Trainer starts with 0 badges.
        public Trainer(string name)
        {
            this.Name = name;
            this.Badges = 0;
            this.Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }

        public int Badges { get; set; }

        public List<Pokemon> Pokemons { get; set; }
    }
}
