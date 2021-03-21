namespace PlayersAndMonsters.Core
{
    using System;
    using System.Linq;
    using System.Text;

    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private ManagerController mc;

        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;

            this.mc = new ManagerController();
        }

        public void Run()
        {
            this.ReadCommand();
        }

        private void ReadCommand()
        {
            string command;
            while ((command = this.reader.ReadLine()) != "Exit")
            {
                var args = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var action = args[0];

                try
                {
                    this.ProcceedCommand(args, action);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }

        private void ProcceedCommand(string[] args, string action)
        {
            string output;
            if (action == "AddPlayer")
            {
                var playerType = args[1];
                var playerUsername = args[2];

                output = mc.AddPlayer(playerType, playerUsername);
            }
            else if (action == "AddCard")
            {
                var cardType = args[1];
                var cardName = args[2];

                output = mc.AddCard(cardType, cardName);
            }
            else if (action == "AddPlayerCard")
            {
                var username = args[1];
                var cardName = args[2];

                output = mc.AddPlayerCard(username, cardName);
            }
            else if (action == "Fight")
            {
                var attacker = args[1];
                var enemy = args[2];

                output = mc.Fight(attacker, enemy);
            }
            else
            {
                output = this.mc.Report();
            }

            this.writer.WriteLine(output);
        }
    }
}
