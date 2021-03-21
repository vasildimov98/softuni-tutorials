namespace PlayersAndMonsters.Core
{
    using System.Linq;

    using Common;
    using Contracts;
    using Repositories;
    using Core.Factories;
    using Models.BattleFields;
    using System;

    public class ManagerController : IManagerController
    {
        private readonly PlayerRepository playerRepository;
        private readonly CardRepository cardRepository;
        private readonly BattleField battleField;
                 
        private readonly PlayerFactory playerFactory;
        private readonly CardFactory cardFactory;

        public ManagerController()
        {
            this.playerRepository = new PlayerRepository();
            this.cardRepository = new CardRepository();

            this.playerFactory = new PlayerFactory();
            this.cardFactory = new CardFactory();
            this.battleField = new BattleField();
        }

        public string AddPlayer(string type, string username)
        {
            var player = playerFactory.CreatePlayer(type, username);

            this.playerRepository.Add(player);

            var outputMessage = string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);

            return outputMessage;
        }
        public string AddCard(string type, string name)
        {
            var card = cardFactory.CreateCard(type, name);

            this.cardRepository.Add(card);

            var outputMessage = string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);

            return outputMessage;
        }
        public string AddPlayerCard(string username, string cardName)
        {
            var player = this.playerRepository.Find(username);
            var card = this.cardRepository.Find(cardName);

            player.CardRepository.Add(card);

            var outputMessage = string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);

            return outputMessage;
        }
        public string Fight(string attackUser, string enemyUser)
        {
            var attacker = this.playerRepository.Find(attackUser);
            var enemy = this.playerRepository.Find(enemyUser);

            this.battleField.Fight(attacker, enemy);

            var outputMessage = string.Format(ConstantMessages.FightInfo, attacker.Health, enemy.Health);

            return outputMessage;
        }
        public string Report()
        {
            return this.playerRepository.ToString();
        }
    }
}
