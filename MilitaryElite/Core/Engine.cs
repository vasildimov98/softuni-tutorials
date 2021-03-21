namespace MilitaryElite.Core
{
    using System.Linq;
    using MilitaryElite.Contracts;
    using MilitaryElite.IO;
    using System.Collections.Generic;
    using System;
    using MilitaryElite.Modules;

    public class Engine : IEngine
    {
        private ICollection<ISoldier> soldiers;

        private IReadable reader;
        private IWritable writer;
        private Engine()
        {
            this.soldiers = new List<ISoldier>();
        }
        public Engine(IReadable reader, IWritable writer)
            : this()
        {
            this.writer = writer;
            this.reader = reader;
        }
        public void Run()
        {
            FillCollection();
            PrintOutput();
        }

        private void PrintOutput()
        {
            foreach (var soldier in this.soldiers)
            {
                writer.WriteLine(soldier.ToString());
            }
        }

        private void FillCollection()
        {
            string commad;
            while ((commad = reader.ReadLine()) != "End")
            {
                try
                {
                    CollectAllSoldiers(commad);
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }

        private void CollectAllSoldiers(string commad)
        {
            var cmdArg = commad
                .Split(' ', System.StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var type = cmdArg[0];
            var id = cmdArg[1];
            var firstName = cmdArg[2];
            var lastName = cmdArg[3];

            if (type == "Private")
            {
                GetPrivate(cmdArg.Skip(4).ToArray(), id, firstName, lastName);
            }
            else if (type == "LieutenantGeneral")
            {
                GetLieutenantGeneral(cmdArg.Skip(4).ToArray(), id, firstName, lastName);
            }
            else if (type == "Engineer")
            {
                GetEngeneer(cmdArg.Skip(4).ToArray(), id, firstName, lastName);
            }
            else if (type == "Commando")
            {
                GetCommando(cmdArg.Skip(4).ToArray(), id, firstName, lastName);
            }
            else if (type == "Spy")
            {
                GetSpy(cmdArg.Skip(4).ToArray(), id, firstName, lastName);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private void GetSpy(string[] arg, string id, string firstName, string lastName)
        {
            var codeNumber = int.Parse(arg[0]);
            var spy = new Spy(id, firstName, lastName, codeNumber);
            this.soldiers.Add(spy);
        }

        private void GetCommando(string[] cmdArg, string id, string firstName, string lastName)
        {
            var salary = decimal.Parse(cmdArg[0]);
            var corps = cmdArg[1];
            var commando = new Commando(id, firstName, lastName, salary, corps);

            GetAllMission(cmdArg.Skip(2).ToArray(), commando);

            this.soldiers.Add(commando);
        }

        private static void GetAllMission(string[] cmdArg, Commando commando)
        {
            for (int i = 0; i < cmdArg.Length; i += 2)
            {
                var codeName = cmdArg[i];
                var state = cmdArg[i + 1];

                try
                {
                    var mission = new Mission(codeName, state);
                    commando.AddMission(mission);
                }
                catch (Exception)
                {
                    continue;
                }

            }
        }

        private void GetEngeneer(string[] cmdArg, string id, string firstName, string lastName)
        {
            var salary = decimal.Parse(cmdArg[0]);
            var corps = cmdArg[1];
            var engineer = new Engineer(id, firstName, lastName, salary, corps);
            GetAllRepairs(cmdArg.Skip(2).ToArray(), engineer);
            this.soldiers.Add(engineer);
        }

        private static void GetAllRepairs(string[] cmdArg, Engineer engineer)
        {
            for (int i = 0; i < cmdArg.Length; i += 2)
            {
                var repairPart = cmdArg[i];
                var repairHours = int.Parse(cmdArg[i + 1]);

                var repair = new Repair(repairPart, repairHours);

                engineer.AddRepair(repair);
            }
        }

        private void GetLieutenantGeneral(string[] cmdArg, string id, string firstName, string lastName)
        {
            var salary = decimal.Parse(cmdArg[0]);
            var lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

            AddAllPrivates(cmdArg.Skip(1).ToArray(), lieutenantGeneral);

            this.soldiers.Add(lieutenantGeneral);
        }

        private void AddAllPrivates(string[] cmdArg, LieutenantGeneral lieutenantGeneral)
        {
            for (int i = 0; i < cmdArg.Length; i++)
            {
                var @private = this.soldiers
                    .FirstOrDefault(p => p.Id == cmdArg[i]);

                lieutenantGeneral.AddPrivate((IPrivate)@private);
            }
        }

        private void GetPrivate(string[] cmdArg,
            string id,
            string firstName,
            string lastName)
        {
            Private @private;
            var salary = decimal.Parse(cmdArg[0]);

            @private = new Private(id, firstName, lastName, salary);

            this.soldiers.Add(@private);
        }
    }
}
