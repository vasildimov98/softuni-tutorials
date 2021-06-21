namespace MilitaryElite.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Models;
    using Contracts;
    using IO.Contracts;
    using MilitaryElite.Contracts;
    using MilitaryElite.Enumerators;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
               
        private readonly ICollection<ISoldier> soldiers;
                
        private readonly ICollection<Private> privates;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;

            soldiers = new List<ISoldier>();
            privates = new List<Private>();
        }

        public void Run()
        {
            this.CollectAllSoldiers();
            this.PrintResult();
        }

        private void PrintResult()
        {
            foreach (var soldier in this.soldiers)
            {
               writer.WriteLine(soldier.ToString());
            }
        }

        private void CollectAllSoldiers()
        {
            string command;
            while ((command = reader.ReadLine()) != "End")
            {
                var args = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var soldierToCreate = args[0];

                var id = int.Parse(args[1]);
                var firstName = args[2];
                var lastName = args[3];

                if (soldierToCreate == "Private")
                {
                    var salary = decimal.Parse(args[4]);
                    this.CreatePrivate(id, firstName, lastName, salary);
                }
                else if (soldierToCreate == "LieutenantGeneral")
                {
                    var salary = decimal.Parse(args[4]);
                    this.CreateLieutenantGeneral(args, id, firstName, lastName, salary);
                }
                else if (soldierToCreate == "Engineer")
                {
                    var salary = decimal.Parse(args[4]);

                    var IsParsed = Enum.TryParse(args[5], false, out Corps corps);

                    if (!IsParsed)
                    {
                        continue;
                    }

                    this.CreateEngineer(args, id, firstName, lastName, salary, corps);
                }
                else if (soldierToCreate == "Commando")
                {
                    var salary = decimal.Parse(args[4]);

                    var IsParsed = Enum.TryParse(args[5], false, out Corps corps);

                    if (!IsParsed)
                    {
                        continue;
                    }

                    this.CreateCommando(args, id, firstName, lastName, salary, corps);
                }
                else
                {
                    var codeNumber = int.Parse(args[4]);
                    var spy = new Spy(id, firstName, lastName, codeNumber);
                    this.soldiers.Add(spy);
                }
            }
        }

        private void CreateCommando(string[] args, int id, string firstName, string lastName, decimal salary, Corps corps)
        {
            var commando = new Commando(id, firstName, lastName, salary, corps);

            var missionArgs = args
                .Skip(6)
                .ToArray();

            AddMission(commando, missionArgs);

            this.soldiers.Add(commando);
        }

        private static void AddMission(Commando commando, string[] missionArgs)
        {
            for (int i = 0; i < missionArgs.Length; i += 2)
            {
                var codeName = missionArgs[i];
                var missionState = missionArgs[i + 1];

                var IsState = Enum.TryParse(missionState, false, out State state);

                if (!IsState)
                {
                    continue;
                }

                var mission = new Mission(codeName, state);

                commando.AddMission(mission);
            }
        }

        private void CreateEngineer(string[] args, int id, string firstName, string lastName, decimal salary, Corps corps)
        {
            var engineer = new Engineer(id, firstName, lastName, salary, corps);

            var repairArgs = args
                .Skip(6)
                .ToArray();

            for (int i = 0; i < repairArgs.Length; i += 2)
            {
                this.AddRepair(engineer, repairArgs, i);
            }

            this.soldiers.Add(engineer);
        }

        private void AddRepair(Engineer engineer, string[] repairArgs, int i)
        {
            var repairName = repairArgs[i];
            var workedHour = int.Parse(repairArgs[i + 1]);

            var repair = new Repair(repairName, workedHour);

            engineer.AddReapir(repair);
        }

        private void CreateLieutenantGeneral(string[] args, int id, string firstName, string lastName, decimal salary)
        {
            var soldier = new LieutenantGeneral(id, firstName, lastName, salary);

            foreach (var privateId in args
                .Skip(5)
                .Select(int.Parse)
                .ToArray())
            {
                var @private = this.privates
                    .FirstOrDefault(pr => pr.Id == privateId);

                soldier.AddPrivate(@private);
            }

            soldiers.Add(soldier);
        }

        private void CreatePrivate(int id, string firstName, string lastName, decimal salary)
        {
            var soldier = new Private(id, firstName, lastName, salary);
            privates.Add(soldier);
            soldiers.Add(soldier);
        }
    }
}
