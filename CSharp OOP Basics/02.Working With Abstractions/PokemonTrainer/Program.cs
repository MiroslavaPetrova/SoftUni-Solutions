using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string input = Console.ReadLine();

            while (input != "Tournament")
            {
                //“<TrainerName> <PokemonName> <PokemonElement> <PokemonHealth>
                string[] inputArgs = input.Split();

                string trainerName = inputArgs[0];
                string pokemonName = inputArgs[1];
                string pokemonElement = inputArgs[2];
                int pokemonHealth = int.Parse(inputArgs[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.Any(t => t.Name == trainerName))
                {
                    trainers.Add(new Trainer(trainerName));
                }

                Trainer trainer = trainers.FirstOrDefault(t => t.Name == trainerName);
                trainer.Pokemons.Add(pokemon);
               
                input = Console.ReadLine();
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string element = command;

                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == element))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                          
                        }
                    }

                    //trainer.Pokemons = trainer.Pokemons.Where(p => p.Health > 0).ToList();
                   
                    trainer.Pokemons.RemoveAll(p => p.Health <= 0);
                }

                command = Console.ReadLine();
            }
            
            foreach (var trainer in trainers.OrderByDescending(t=> t.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}
