using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string input = Console.ReadLine();
            while (input != "Tournament")
            {
                //TrainerName PokemonName PokemonElement PokemonHealth”
                string[] info = input.Split();
                string trainerName = info[0];
                string pokemonName = info[1];
                string pokemonElement = info[2];
                int pokemonHealth = int.Parse(info[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                List<Pokemon> pokemons = new List<Pokemon>();
                pokemons.Add(pokemon);

                if (!trainers.Any(n => n.Name == trainerName))
                {
                    trainers.Add(new Trainer(trainerName,pokemons)); 
                }
                Trainer trainer = trainers.First(t => t.Name == trainerName);
                trainer.Pokemons.Add(pokemon);

                input = Console.ReadLine();
            }
            string elementToCheck = Console.ReadLine();

            while (elementToCheck != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == elementToCheck))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }
                        trainer.Pokemons = trainer.Pokemons.Where(p => p.Health > 0).ToList();
                    }
                }
                elementToCheck = Console.ReadLine();
            }
            Console.WriteLine();
            foreach (var trainer in trainers.OrderByDescending(t => t.Badges))
            {
                Console.Write($"{trainer.Name} ");
                Console.WriteLine($"{trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}
