namespace OnlineShop.Models.Products.Computers
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    using Components;
    using Peripherals;
    using OnlineShop.Common.Constants;

    public abstract class Computer : Product, IComputer
    {
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherals;

        protected Computer(int id,
            string manufacturer,
            string model,
            decimal price,
            double overallPerformance)
            : base(id,
                  manufacturer,
                  model,
                  price,
                  overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components
            => (IReadOnlyCollection<IComponent>)this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals
            => (IReadOnlyCollection<IPeripheral>)this.peripherals;

        public override double OverallPerformance
         => this.components.Count == 0 ?
                base.OverallPerformance :
                base.OverallPerformance + this.components.Average(c => c.OverallPerformance);

        public override decimal Price
            => base.Price
            + this.components.Sum(c => c.Price)
            + this.peripherals.Sum(p => p.Price);

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb
                .AppendLine(base.ToString())
                .AppendLine($" Components ({this.Components.Count}):");

            foreach (var component in this.Components)
            {
                sb.AppendLine($"  {component}");
            }

            var peripheralOverallPerformance = this.Peripherals.Count == 0 ? 0 : this.Peripherals.Average(p => p.OverallPerformance);

            sb.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({peripheralOverallPerformance:F2}):");

            foreach (var peripheral in this.Peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return sb.ToString().TrimEnd();
        }

        public void AddComponent(IComponent component)
        {
            var componentType = component.GetType().Name;
            if (this.components.Any(c => c.GetType().Name == componentType))
            {
                var computerType = this.GetType().Name;
                var msg = string.Format(ExceptionMessages.ExistingComponent,
                    componentType, computerType, base.Id);
                this.ThrowArgumentException(msg);
            }

            this.components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            var component = this.Components
                .FirstOrDefault(c => c.GetType().Name == componentType);

            if (component == null)
            {
                var computerType = this.GetType().Name;
                var msg = string.Format(ExceptionMessages.NotExistingComponent,
                    componentType, computerType, base.Id);
                this.ThrowArgumentException(msg);
            }

            this.components.Remove(component);

            return component;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            var peripheralType = peripheral.GetType().Name;
            if (this.peripherals.Any(c => c.GetType().Name == peripheralType))
            {
                var computerType = this.GetType().Name;
                var msg = string.Format(ExceptionMessages.ExistingPeripheral,
                    peripheralType, computerType, base.Id);
                this.ThrowArgumentException(msg);
            }

            this.peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            var peripheral = this.Peripherals
                .FirstOrDefault(c => c.GetType().Name == peripheralType);

            if (peripheral == null)
            {
                var computerType = this.GetType().Name;
                var msg = string.Format(ExceptionMessages.NotExistingPeripheral,
                    peripheralType, computerType, base.Id);
                this.ThrowArgumentException(msg);
            }

            this.peripherals.Remove(peripheral);

            return peripheral;
        }

        private void ThrowArgumentException(string msg)
        {
            throw new ArgumentException(msg);
        }
    }
}
