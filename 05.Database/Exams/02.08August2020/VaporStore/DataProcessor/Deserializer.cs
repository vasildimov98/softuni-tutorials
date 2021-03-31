namespace VaporStore.DataProcessor
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Newtonsoft.Json;

    using Data;
    using Dto.Import;
    using Data.Models;
    using Data.Models.Enums;

    using XmlHelper;
    using System.Globalization;

    public static class Deserializer
    {
        private const string ErroMessage = "Invalid Data";

        public static string ImportGames(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var gamesDtos = JsonConvert.DeserializeObject<IEnumerable<GameJsonImportDto>>(jsonString);

            foreach (var gameDto in gamesDtos)
            {
                if (!IsValid(gameDto))
                {
                    sb.AppendLine(ErroMessage);
                    continue;
                }

                var developer = context.Developers
                    .FirstOrDefault(x => x.Name == gameDto.Developer) ??
                    new Developer { Name = gameDto.Developer };

                var genre = context.Genres
                    .FirstOrDefault(x => x.Name == gameDto.Genre) ??
                    new Genre { Name = gameDto.Genre };

                var game = new Game
                {
                    Name = gameDto.Name,
                    Price = gameDto.Price,
                    ReleaseDate = (DateTime)gameDto.ReleaseDate,
                    Developer = developer,
                    Genre = genre,
                };

                foreach (var tagName in gameDto.Tags.Select(x => x))
                {
                    var tag = context.Tags
                        .FirstOrDefault(x => x.Name == tagName) ??
                        new Tag { Name = tagName };

                    var gameTag = new GameTag
                    {
                        Tag = tag
                    };

                    game.GameTags.Add(gameTag);
                }

                context.Games.Add(game);
                context.SaveChanges();

                sb.AppendLine($"Added {gameDto.Name} ({gameDto.Genre}) with {gameDto.Tags.Count()} tags");
            }

            var output = sb.ToString();

            return output;
        }

        public static string ImportUsers(VaporStoreDbContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var usersDtos = JsonConvert
                .DeserializeObject<IEnumerable<UserJsonImportDto>>(jsonString);

            foreach (var userDto in usersDtos)
            {
                if (!IsValid(userDto)
                    || !userDto.Cards.All(IsValid))
                {
                    sb.AppendLine(ErroMessage);
                    continue;
                }

                var user = new User
                {
                    Username = userDto.Username,
                    FullName = userDto.FullName,
                    Age = userDto.Age,
                    Email = userDto.Email
                };

                foreach (var cardDto in userDto.Cards)
                {
                    var card = new Card
                    {
                        Cvc = cardDto.CVC,
                        Type = (CardType)cardDto.Type,
                        Number = cardDto.Number,
                    };

                    user.Cards.Add(card);
                }

                context.Users.Add(user);
                context.SaveChanges();

                sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
            }

            var output = sb.ToString();

            return output;
        }

        public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var purchasesDtos = XmlConvert
                .Deserialize<PurchaseJsonImportDto[]>("Purchases", xmlString);

            foreach (var purchaseDto in purchasesDtos)
            {
                if (!IsValid(purchaseDto))
                {
                    sb.AppendLine(ErroMessage);
                    continue;
                }

                var game = context.Games
                    .FirstOrDefault(x => x.Name == purchaseDto.GameName);

                var card = context.Cards
                    .FirstOrDefault(x => x.Number == purchaseDto.CardNumber);

                var date = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                var purchase = new Purchase
                {
                    Game = game,
                    ProductKey = purchaseDto.Key,
                    Type = (PurchaseType)purchaseDto.Type,
                    Card = card,
                    Date = date,
                };

                context.Purchases.Add(purchase);

                sb.AppendLine($"Imported {game.Name} for {card.User.Username}");
            }

            context.SaveChanges();

            var output = sb.ToString();

            return output;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}