namespace ViceCity.Models.Neghbourhoods
{
    using System.Linq;
    using System.Collections.Generic;

    using Contracts;
    using Guns.Contracts;
    using Players.Contracts;

    public class GangNeighbourhood : INeighbourhood
    {
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            this.MainPlayerShoots(mainPlayer, civilPlayers);
            this.AliveCivilShoots(mainPlayer, civilPlayers);
        }

        private void AliveCivilShoots(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            foreach (var civil in civilPlayers)
            {
                while (civil.GunRepository.Models.Any() 
                    && mainPlayer.IsAlive)
                {
                    var currGun = civil
                    .GunRepository
                    .Models
                    .First();

                    this.TryShoot(civil, currGun, mainPlayer);

                    if (!mainPlayer.IsAlive)
                    {
                        return;
                    }
                }
            }
        }

        private void MainPlayerShoots(IPlayer player, ICollection<IPlayer> civilPlayer)
        {
            while (player.GunRepository.Models.Any()
                && civilPlayer.Any(c => c.IsAlive))
            {
                var currGun = player
                    .GunRepository
                    .Models
                    .First();

                var currCivil = civilPlayer.First(c => c.IsAlive);

                this.TryShoot(player, currGun, currCivil);
            }
        }

        private void TryShoot(IPlayer shooter, IGun currGun, IPlayer target)
        {
            if (currGun.TotalBullets == 0)
            {
                shooter.GunRepository.Remove(currGun);
            }
            else
            {
                var demage = currGun.Fire();

                target.TakeLifePoints(demage);
            }
        }
    }
}
