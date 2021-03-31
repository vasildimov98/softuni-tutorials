namespace VaporStore.DataProcessor
{
	using System;
    using System.Linq;
	using System.Globalization;

	using Newtonsoft.Json;

    using Data;
    using Dto.Export;
    using VaporStore.XmlHelper;

    public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
			var gamesToExport = context.Genres
				.AsEnumerable()
				.Where(x => genreNames.Contains(x.Name))
				.Select(x => new
				{
					x.Id,
					Genre = x.Name,
					Games = x.Games
						.Where(x => x.Purchases.Any())
						.Select(y => new
						{
							y.Id,
							Title = y.Name,
							Developer = y.Developer.Name,
							Tags = string.Join(", ", y.GameTags
								.Select(z => z.Tag.Name)),
							Players = y.Purchases.Count()
						})
						.OrderByDescending(y => y.Players)
						.ThenBy(y => y.Id),
					TotalPlayers = x.Games.Sum(y => y.Purchases.Count)
				})
				.OrderByDescending(x => x.TotalPlayers)
				.ThenBy(x => x.Id);

			var gamesJsonOutput = JsonConvert.SerializeObject(gamesToExport, Formatting.Indented);

			return gamesJsonOutput;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
			var usersToExport = context.Users
				.ToList()
				.Where(x => x.Cards.Any(x => x.Purchases.Any()))
				.Select(x => new UserXmlExportDto
				{
					Username = x.Username,
					Purchases = x.Cards
						.SelectMany(x => x.Purchases)
						.Where(x => x.Type.ToString() == storeType)
						.Select(x => new PurchaseXmlExportDto
						{
							Card = x.Card.Number,
							Cvc = x.Card.Cvc,
							Date = x.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
							Game = new GameXmlExportDto
							{
								Name = x.Game.Name,
								Genre = x.Game.Genre.Name,
								Price = x.Game.Price
							}
						})
						.OrderBy(x => x.Date)
						.ToArray(),
					TotalSpent = x.Cards
						.SelectMany(x => x.Purchases)
						.Where(x => x.Type.ToString() == storeType)
						.Sum(x => x.Game.Price)
				})
				.Where(x => x.Purchases.Length != 0)
				.OrderByDescending(x => x.TotalSpent)
				.ThenBy(x => x.Username)
				.ToArray();

			var xmlOutput = XmlConvert.Serialize("Users", usersToExport);

			return xmlOutput;
		}
	}
}