using System;
using System.Collections.Generic;
using System.Linq;

namespace P09.PokemonTrainer
{
    public class StartUp
    {
        static void Main()
        {
            var trainers = new List<Trainers>();
            GetAllTrainers(trainers);
            ProcessTrainers(trainers);

            var orderList = trainers
                .OrderByDescending(tr => tr.NumberOfBadges)
                .ToList();


            Console.WriteLine(string.Join(Environment.NewLine, orderList));
        }

        private static void ProcessTrainers(List<Trainers> trainers)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    CheckElementsInPokemons(command, trainer);
                }
            }
        }

        private static void CheckElementsInPokemons(string command, Trainers trainer)
        {
            if (trainer.MyPokemons.Any(p => p.Element == command))
            {
                trainer.NumberOfBadges++;
            }
            else
            {
                for (int i = 0; i < trainer.MyPokemons.Count; i++)
                {
                    var pokemon = trainer.MyPokemons[i];
                    pokemon.Health -= 10;

                    if (pokemon.Health <= 0)
                    {
                        trainer.MyPokemons.Remove(pokemon);
                        i--;
                    }
                }

            }
        }

        private static void GetAllTrainers(List<Trainers> trainers)
        {
            string command;
            while ((command = Console.ReadLine()) != "Tournament")
            {
                var trainerArg = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var trainerName = trainerArg[0];

                if (!trainers.Any(t => t.Name == trainerName))
                {
                    var trainer = new Trainers(trainerName);
                    trainers.Add(trainer);
                }

                var pokemonName = trainerArg[1];
                var pokemonElement = trainerArg[2];
                var pokemonHealth = double.Parse(trainerArg[3]);

                var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                trainers.Where(t => t.Name == trainerName).First().MyPokemons.Add(pokemon);
            }
        }
    }
}
