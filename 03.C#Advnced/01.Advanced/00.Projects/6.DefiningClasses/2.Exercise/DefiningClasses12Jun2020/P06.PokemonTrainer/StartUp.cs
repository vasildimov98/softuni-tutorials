namespace P06.PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static List<Trainer> trainers;
        public static void Main()
        {
            trainers = new List<Trainer>();

            GetAllTrainers();

            FightInTournament();

            PrintTrainers();
        }

        private static void PrintTrainers()
        {
            foreach (var trainer in trainers
                .OrderByDescending(tr => tr.NumberOfBadges))
            {
                Console.WriteLine(trainer);
            }
        }

        private static void FightInTournament()
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                trainers
                    .ForEach(t => t.FightWithPokemon(command));
            }
        }

        private static void GetAllTrainers()
        {
            string command;
            while ((command = Console.ReadLine()) != "Tournament")
            {
                var args = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var trainerName = args[0];

                var pokemonName = args[1];
                var pokemonElement = args[2];
                var pokemonHealth = int.Parse(args[3]);

                Trainer trainer;
                if (!trainers.Any(t => t.Name == trainerName))
                {
                    trainer = new Trainer(trainerName);

                    var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                    trainer.AddPokemon(pokemon);

                    trainers.Add(trainer);
                }
                else
                {
                    trainer = trainers
                        .FirstOrDefault(t => t.Name == trainerName);

                    var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                    trainer.AddPokemon(pokemon);
                }
            }
        }
    }
}
