namespace PlayersAndMonsters.Models.BattleFields
{
    using System;
    using System.Linq;

    using Common;
    using Players;
    using Contracts;
    using Players.Contracts;

    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException(ExceptionMessages.InvalidDeadPlayer);
            }

            CheckForBeginersPlayers(attackPlayer);
            CheckForBeginersPlayers(enemyPlayer);

            GetBonusHealthPoints(attackPlayer);
            GetBonusHealthPoints(enemyPlayer);

            while (!attackPlayer.IsDead && !enemyPlayer.IsDead)
            {
                enemyPlayer.TakeDamage(GetDamgePoints(attackPlayer));

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                attackPlayer.TakeDamage(GetDamgePoints(enemyPlayer));
            }
        }

        private static int GetDamgePoints(IPlayer player)
        {
            return player.CardRepository.Cards.Sum(c => c.DamagePoints);
        }
        private static void GetBonusHealthPoints(IPlayer player)
        {
            player.Health += player
                .CardRepository
                .Cards
                .Sum(c => c.HealthPoints);
        }
        private static void CheckForBeginersPlayers(IPlayer player)
        {
            if (player.GetType().Name == nameof(Beginner))
            {
                IncreaseValueOfPlayer(player);
            }
        }
        private static void IncreaseValueOfPlayer(IPlayer player)
        {
            player.Health += 40;

            foreach (var car in player.CardRepository.Cards)
            {
                car.DamagePoints += 30;
            }
        }
    }
}
