namespace MortalEngines.Core
{
    using System.Linq;
    using System.Collections.Generic;

    using Common;
    using Entities;
    using Contracts;
    using Entities.Contracts;

    public class MachinesManager : IMachinesManager
    {
        private readonly ICollection<IPilot> pilots;
        private readonly ICollection<IMachine> machines;

        public MachinesManager()
        {
            this.pilots = new List<IPilot>();
            this.machines = new List<IMachine>();
        }

        public string HirePilot(string name)
        {
            if (this.pilots.Any(p => p.Name == name))
            {
                return string.Format(OutputMessages.PilotExists, name);
            }

            this.pilots.Add(new Pilot(name));

            return string.Format(OutputMessages.PilotHired, name);
        }
        public string PilotReport(string pilotReporting)
        {
            var pilot = this.pilots
                 .First(p => p.Name == pilotReporting);

            return pilot.Report();
        }
        public string MachineReport(string machineName)
        {
            var machine = this.machines
                .First(m => m.Name == machineName);

            return machine.ToString();
        }
        public string ManufactureTank(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(m => m.Name == name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            var tank = new Tank(name, attackPoints, defensePoints);

            this.machines.Add(tank);

            return string.Format(OutputMessages
                .TankManufactured,
                name,
                tank.AttackPoints,
                tank.DefensePoints,
                tank
                .DefenseMode ? "ON" : "OFF");
        }
        public string ToggleTankDefenseMode(string tankName)
        {
            if (!this.machines.Any(m => m.Name == tankName))
            {
                return string.Format(OutputMessages.MachineNotFound, tankName);
            }

            var tank = (Tank)this.machines
                .First(m => m.Name == tankName);

            tank.ToggleDefenseMode();

            return string.Format(OutputMessages.TankOperationSuccessful, tankName);
        }
        public string ManufactureFighter(string name, double attackPoints, double defensePoints)
        {
            if (this.machines.Any(m => m.Name == name))
            {
                return string.Format(OutputMessages.MachineExists, name);
            }

            var fighter = new Fighter(name, attackPoints, defensePoints);

            this.machines.Add(fighter);

            return string.Format(OutputMessages
                .FighterManufactured,
                name,
                fighter.AttackPoints,
                fighter.DefensePoints,
                fighter
                .AggressiveMode ? "ON" : "OFF");
        }
        public string ToggleFighterAggressiveMode(string fighterName)
        {
            if (!this.machines.Any(m => m.Name == fighterName))
            {
                return string.Format(OutputMessages.MachineNotFound, fighterName);
            }

            var fighter = (Fighter)this.machines
                .First(m => m.Name == fighterName);

            fighter.ToggleAggressiveMode();

            return string.Format(OutputMessages.FighterOperationSuccessful, fighterName);
        }
        public string EngageMachine(string selectedPilotName, string selectedMachineName)
        {
            if (!this.pilots.Any(p => p.Name == selectedPilotName))
            {
                return string.Format(OutputMessages.PilotNotFound, selectedPilotName);
            }
            else if (!this.machines.Any(m => m.Name == selectedMachineName))
            {
                return string.Format(OutputMessages.MachineNotFound, selectedMachineName);
            }

            var machine = this.machines
                .First(m => m.Name == selectedMachineName);

            if (machine.Pilot != null)
            {
                return string.Format(OutputMessages.MachineHasPilotAlready, selectedMachineName);
            }

            var pilot = this.pilots.First(p => p.Name == selectedPilotName);
            machine.Pilot = pilot;
            pilot.AddMachine(machine);

            return string.Format(OutputMessages.MachineEngaged, selectedPilotName, selectedMachineName);
        }
        public string AttackMachines(string attackingMachineName, string defendingMachineName)
        {
            if (!this.machines.Any(m => m.Name == attackingMachineName))
            {
                return string.Format(OutputMessages.MachineNotFound, attackingMachineName);
            }
            else if (!this.machines.Any(m => m.Name == defendingMachineName))
            {
                return string.Format(OutputMessages.MachineNotFound, defendingMachineName);
            }

            var attacker = this.machines
                .First(m => m.Name == attackingMachineName);

            var defender = this.machines
               .First(m => m.Name == defendingMachineName);

            if (attacker.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, attackingMachineName);
            }
            else if (defender.HealthPoints == 0)
            {
                return string.Format(OutputMessages.DeadMachineCannotAttack, defendingMachineName);
            }

            attacker.Attack(defender);

            var currHealth = defender.HealthPoints;

            return string.Format(OutputMessages.AttackSuccessful, defendingMachineName, attackingMachineName, currHealth);
        }
    }
}