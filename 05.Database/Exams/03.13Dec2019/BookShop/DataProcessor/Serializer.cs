namespace BookShop.DataProcessor
{
    using System;
    using System.Linq;

    using Newtonsoft.Json;

    using Data;
    using ExportDto;
    using XmlHelper;
    using Data.Models.Enums;
    using System.Globalization;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authorsToExport = context.Authors
                .Select(x => new
                {
                    AuthorName = $"{x.FirstName} {x.LastName}",
                    Books = x.AuthorsBooks
                        .OrderByDescending(y => y.Book.Price)
                        .Select(y => new
                        {
                            BookName = y.Book.Name,
                            BookPrice = y.Book.Price.ToString("F2")
                        })
                        .ToArray()
                })
                .ToArray()
                .OrderByDescending(x => x.Books.Length)
                .ThenBy(x => x.AuthorName)
                .ToArray();

            var jsonOutput = JsonConvert.SerializeObject(authorsToExport, Formatting.Indented);

            return jsonOutput;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var booksToExport = context.Books
                .Where(x => x.PublishedOn < date && x.Genre == Genre.Science)
                .AsEnumerable()
                .OrderByDescending(x => x.Pages)
                .ThenByDescending(x => x.PublishedOn)
                .Select(x => new BookXmlExportDto
                {
                    Pages = x.Pages,
                    Name = x.Name,
                    Date = x.PublishedOn.ToString("d", CultureInfo.InvariantCulture)
                })
                .Take(10)
                .ToArray();

            var xmlOutput = XmlConvert.Serialize("Books", booksToExport);

            return xmlOutput;
        }
    }
}