namespace CounterStrike.Core
{
    using Contracts;
    using CounterStrike.Models.Guns;
    using CounterStrike.Models.Players;
    using CounterStrike.Utilities.Messages;
    using Models.Guns.Contracts;
    using Models.Maps;
    using Models.Maps.Contracts;
    using Models.Players.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using System;
    using System.Linq;
    using System.Reflection.Metadata.Ecma335;
    using System.Text;

    public class Controller : IController
    {
        private readonly IRepository<IGun> guns;
        private readonly IRepository<IPlayer> players;
        private readonly IMap maps;

        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.maps = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun;
            if (type == nameof(Pistol))
            {
                gun = new Pistol(name, bulletsCount);
            }
            else if (type == nameof(Rifle))
            {
                gun = new Rifle(name, bulletsCount);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }

            this.guns.Add(gun);

            return string.Format(OutputMessages.SuccessfullyAddedGun, gun.Name);
        }
        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            var gun = this.guns.FindByName(gunName);

            if (gun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            IPlayer player;
            if (type == nameof(Terrorist))
            {
                player = new Terrorist(username, health, armor, gun);
            }
            else if (type == nameof(CounterTerrorist))
            {
                player = new CounterTerrorist(username, health, armor, gun);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }

            this.guns.Remove(gun);
            this.players.Add(player);

            return string.Format(OutputMessages.SuccessfullyAddedPlayer, player.Username);
        }
        public string StartGame()
        {
            var alivePlayers = this.players
                .Models
                .Where(p => p.IsAlive)
                .ToList();

            return this.maps.Start(alivePlayers);
        }
        public string Report()
        {
            var orderedPlayer = this.players
                .Models
                .OrderBy(p => p.GetType().Name)
                .ThenByDescending(p => p.Health)
                .ThenBy(p => p.Username)
                .ToArray();

            var sb = new StringBuilder();

            foreach (var player in orderedPlayer)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
