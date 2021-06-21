namespace MortalEngines.Core
{
    using System;
    using Contracts;
    public class Engine : IEngine
    {
        private readonly MachinesManager machinesManager;

        public Engine()
        {
            machinesManager = new MachinesManager();
        }

        public void Run()
        {
            string line = Console.ReadLine();

            while (line != "Quit")
            {
                string[] commandItems = line.Split();
                string result = string.Empty;

                try
                {
                    switch (commandItems[0])
                    {
                        case "HirePilot":
                            result += machinesManager.HirePilot(commandItems[1]);
                            break;

                        case "PilotReport":
                            result += machinesManager.PilotReport(commandItems[1]);
                            break;

                        case "ManufactureTank":
                            result += machinesManager.ManufactureTank(commandItems[1],
                                double.Parse(commandItems[2]),
                                double.Parse(commandItems[3]));
                            break;

                        case "ManufactureFighter":
                            result += machinesManager.ManufactureFighter(
                                commandItems[1],
                                double.Parse(commandItems[2]),
                                double.Parse(commandItems[3]));
                            break;

                        case "MachineReport":
                            result += machinesManager.MachineReport(commandItems[1]);
                            break;

                        case "AggressiveMode":
                            result += machinesManager.ToggleFighterAggressiveMode(commandItems[1]);
                            break;

                        case "DefenseMode":
                            result += machinesManager.ToggleTankDefenseMode(commandItems[1]);
                            break;

                        case "Engage":
                            result += machinesManager.EngageMachine(commandItems[1], commandItems[2]);
                            break;

                        case "Attack":
                            result += machinesManager.AttackMachines(commandItems[1], commandItems[2]);
                            break;

                        default:
                            break;
                    }

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                line = Console.ReadLine();
            }
        }
    }
}