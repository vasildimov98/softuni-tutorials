namespace CounterStrike.Models.Maps
{
    using Contracts;
    using CounterStrike.Models.Players;
    using CounterStrike.Models.Players.Contracts;
    using CounterStrike.Utilities.Messages;
    using System.Collections.Generic;
    using System.Linq;

    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = players
                .Where(t => t.GetType().Name == nameof(Terrorist))
                .ToArray();

            var counterTerrorists = players
                .Where(t => t.GetType().Name == nameof(CounterTerrorist))
                .ToArray();

            this.Battle(terrorists, counterTerrorists);

            var output = GetOutputMessage(counterTerrorists);

            return output;
        }

        private static string GetOutputMessage(IPlayer[] counterTerrorists)
        {
            string output;
            if (counterTerrorists.Any(p => p.IsAlive))
            {
                output = OutputMessages.CounterTerroristWins;
            }
            else
            {
                output = OutputMessages.TerroristWin;
            }

            return output;
        }

        private void Battle(IPlayer[] terrorists, IPlayer[] counterTerrorists)
        {
            while (terrorists.Any(p => p.IsAlive)
                && counterTerrorists.Any(p => p.IsAlive))
            {
                var aliveTerrorist = terrorists
                    .Where(p => p.IsAlive)
                    .ToArray();

                this.Attack(aliveTerrorist, counterTerrorists);

                var aliveCounterTerrorist = counterTerrorists
                    .Where(p => p.IsAlive)
                    .ToArray();

                this.Attack(aliveCounterTerrorist, aliveTerrorist);
            }
        }

        private void Attack(IPlayer[] attackers, IPlayer[] targets)
        {
            foreach (var pl in attackers)
            {
                var damage = pl.Gun.Fire();

                this.TakeDamage(targets, damage);
            }
        }

        private void TakeDamage(IPlayer[] targets, int damage)
        {
            foreach (var pl in targets)
            {
                pl.TakeDamage(damage);
            }
        }
    }
}
