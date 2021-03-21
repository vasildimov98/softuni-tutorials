namespace ViceCity.Core
{
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    using Common;
    using Contracts;

    using Models.Players;
    using Models.Guns;
    using Models.Guns.Contracts;
    using Models.Neghbourhoods;
    using Models.Players.Contracts;
    using Models.Neghbourhoods.Contracts;

    using Repositories;
    using Repositories.Contracts;

    public class Controller : IController
    {
        private readonly IPlayer mainPlayer;

        private readonly ICollection<IPlayer> civilPlayers;
        private readonly IRepository<IGun> gunRepository;
        private readonly INeighbourhood gangNeighbourhood;

        public Controller()
        {
            this.mainPlayer = new MainPlayer();

            this.civilPlayers = new List<IPlayer>();

            this.gunRepository = new GunRepository();
            this.gangNeighbourhood = new GangNeighbourhood();
        }

        public string AddPlayer(string name)
        {
            var civilPlayer = new CivilPlayer(name);

            this.civilPlayers.Add(civilPlayer);

            var outputMessage = string.Format(ConstantMessages.SUCCESSFULLY_ADDED_PLAYER, civilPlayer.Name);

            return outputMessage;
        }
        public string AddGun(string type, string name)
        {
            IGun gun;
            if (type == nameof(Pistol))
            {
                gun = new Pistol(name);
            }
            else if (type == nameof(Rifle))
            {
                gun = new Rifle(name);
            }
            else
            {
                return ConstantMessages.INVALID_GUN_TYPE;
            }

            this.gunRepository.Add(gun);

            var outputMessage = string.Format(ConstantMessages.SUCCESSFULLY_ADDED_GUN, gun.Name, gun.GetType().Name);

            return outputMessage;
        }
        public string AddGunToPlayer(string name)
        {
            if (!gunRepository.Models.Any())
            {
                return ConstantMessages.EMPTY_GUN_REPOSITORY;
            }

            var gun = gunRepository.Models.First();

            if (this.mainPlayer.Name.Contains(name))
            {
                this.mainPlayer.GunRepository.Add(gun);

                this.gunRepository.Remove(gun);

                return string
                    .Format(ConstantMessages
                    .SUCCESSFULLY_ADDED_GUN_TO_MAIN_PLAYER,
                    gun.Name);
            }

            var player = this.civilPlayers
                .FirstOrDefault(c => c.Name == name);

            if (player == null)
            {
                return ConstantMessages.INEXISTANT_CIVIL_PLAYER;
            }

            player.GunRepository.Add(gun);

            this.gunRepository.Remove(gun);

            var outputMessage = string.Format(ConstantMessages.SUCCESSFULLY_ADDED_GUN_TO_CIVIL_PLAYER, gun.Name, name);

            return outputMessage;
        }
        public string Fight()
        {
            var initPlayerHealth = this.mainPlayer.LifePoints;
            var countOfPlayers = this.civilPlayers.Count;

            this.gangNeighbourhood.Action(this.mainPlayer, this.civilPlayers);

            var sb = new StringBuilder();

            if (this.mainPlayer.LifePoints == initPlayerHealth 
                && this.civilPlayers.Any(cp => cp.IsAlive))
            {
                sb.AppendLine(ConstantMessages.EVERYTHING_IS_ALRIGHT);
            }
            else
            {
                sb
               .AppendLine(ConstantMessages.FISHT_HAPPEND)
               .AppendLine(string.Format(ConstantMessages.TOMMY_LIFT_POINTS, this.mainPlayer.LifePoints))
               .AppendLine(string.Format(ConstantMessages.TOMMY_KILLED_STATUS, this.civilPlayers.Count(c => !c.IsAlive)))
               .AppendLine(string.Format(ConstantMessages.LEFT_PLAYER, this.civilPlayers.Count(c => c.IsAlive)));
            }

            return sb.ToString().TrimEnd();
        }
    }
}
