namespace OnlineShop.Core
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Common.Constants;
    using Models.Products.Computers;
    using Models.Products.Components;
    using Models.Products.Peripherals;

    public class Controller : IController
    {
        private readonly ICollection<IComputer> computers;
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.Any(c => c.Id == id))
            {
                var msg = ExceptionMessages.ExistingComputerId;
                this.ThrowArgumentException(msg);
            }

            IComputer computer = null;
            if (computerType == nameof(DesktopComputer))
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else if (computerType == nameof(Laptop))
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else
            {
                var msg = ExceptionMessages.InvalidComputerType;
                this.ThrowArgumentException(msg);
            }

            this.computers.Add(computer);

            var outputMsg = string.Format(SuccessMessages.AddedComputer, id);

            return outputMsg;
        }

        public string AddComponent(int computerId,
            int id,
            string componentType,
            string manufacturer,
            string model, decimal price,
            double overallPerformance,
            int generation)
        {
            var computer = this.CheckIfComputerExists(computerId);

            if (this.components.Any(c => c.Id == id))
            {
                var msg = ExceptionMessages.ExistingComponentId;
                this.ThrowArgumentException(msg);
            }

            IComponent component = null;
            if (componentType == nameof(CentralProcessingUnit))
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(Motherboard))
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(PowerSupply))
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(RandomAccessMemory))
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(SolidStateDrive))
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == nameof(VideoCard))
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                var msg = ExceptionMessages.InvalidComponentType;

                this.ThrowArgumentException(msg);
            }

            computer.AddComponent(component);
            this.components.Add(component);

            var outputMsg = string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);

            return outputMsg;
        }


        public string RemoveComponent(string componentType, int computerId)
        {
            var computer = this.CheckIfComputerExists(computerId);

            computer.RemoveComponent(componentType);

            var component = this.components
                .FirstOrDefault(c => c.GetType().Name == componentType);

            this.components.Remove(component);

            var msg = string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);

            return msg;
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            var computer = this.CheckIfComputerExists(computerId);

            if (this.peripherals.Any(p => p.Id == id))
            {
                var msg = ExceptionMessages.ExistingPeripheralId;
                this.ThrowArgumentException(msg);
            }

            IPeripheral peripheral = null;
            if (peripheralType == nameof(Headset))
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == nameof(Keyboard))
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == nameof(Monitor))
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == nameof(Mouse))
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                var msg = ExceptionMessages.InvalidPeripheralType;

                this.ThrowArgumentException(msg);
            }

            computer.AddPeripheral(peripheral);
            this.peripherals.Add(peripheral);

            var outputMsg = string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);

            return outputMsg;
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            var computer = this.CheckIfComputerExists(computerId);

            computer.RemovePeripheral(peripheralType);

            var peripheral = this.peripherals
                .FirstOrDefault(p => p.GetType().Name == peripheralType);

            this.peripherals.Remove(peripheral);

            var msg = string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);

            return msg;
        }

        public string BuyComputer(int id)
        {
            var computer = this.CheckIfComputerExists(id);

            this.computers.Remove(computer);

            return computer.ToString();
        }

        public string BuyBest(decimal budget)
        {
            var computer = this
                .computers
                .OrderByDescending(c => c.OverallPerformance)
                .FirstOrDefault(c => c.Price <= budget);

            if (computer == null)
            {
                var msg = string.Format(ExceptionMessages.CanNotBuyComputer, budget);
                this.ThrowArgumentException(msg);
            }

            this.computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            var computer = this.CheckIfComputerExists(id);

            return computer.ToString();
        }

        private void ThrowArgumentException(string msg)
        {
            throw new ArgumentException(msg);
        }

        private IComputer CheckIfComputerExists(int id)
        {
            if (!this.computers.Any(c => c.Id == id))
            {
                var msg = ExceptionMessages.NotExistingComputerId;
                this.ThrowArgumentException(msg);
            }

            return this.computers
                .FirstOrDefault(c => c.Id == id);
        }
    }
}
