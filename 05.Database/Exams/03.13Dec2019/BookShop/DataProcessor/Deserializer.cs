namespace BookShop.DataProcessor
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using XmlHelper;
    using ImportDto;
    using Data.Models;
    using Data.Models.Enums;
    using System.Globalization;
    using Newtonsoft.Json;
    using System.Linq;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var booksDtosToImport = XmlConvert.Deserialize<BookXmlImportDto[]>("Books", xmlString);

            foreach (var bookDto in booksDtosToImport)
            {
                var isDateValid = DateTime.TryParseExact(bookDto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date);

                if (!IsValid(bookDto)
                    || !isDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isGenreIsValid = Enum.IsDefined(typeof(Genre), bookDto.Genre);

                if (!isGenreIsValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var genre = bookDto.Genre;

                var book = new Book
                {
                    Name = bookDto.Name,
                    Price = bookDto.Price,
                    Genre = (Genre)genre,
                    Pages = bookDto.Pages,
                    PublishedOn = date
                };

                context.Books.Add(book);

                sb.AppendLine(string.Format(
                    SuccessfullyImportedBook,
                    bookDto.Name,
                    bookDto.Price));
            }

            context.SaveChanges();

            var output = sb.ToString();

            return output;
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var emails = new List<string>();

            var sb = new StringBuilder();

            var authorsDtosToImport = JsonConvert.DeserializeObject<IEnumerable<AuthorJsonImportDto>>(jsonString);

            foreach (var authorDto in authorsDtosToImport)
            {
                if (!IsValid(authorDto)
                    || emails.Contains(authorDto.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var author = new Author();

                foreach (var bookId in authorDto.Books.Select(x => x.Id))
                {
                    var book = context.Books
                     .Select(x => x.Id)
                     .FirstOrDefault(x => x == bookId);

                    if (book == 0)
                    {
                        continue;
                    }

                    author.AuthorsBooks.Add(new AuthorBook { BookId = book });
                }

                if (author.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                author.FirstName = authorDto.FirstName;
                author.LastName = authorDto.LastName;
                author.Email = authorDto.Email;
                author.Phone = authorDto.Phone;

                context.Authors.Add(author);

                emails.Add(authorDto.Email);

                sb.AppendLine(string.Format(
                    SuccessfullyImportedAuthor,
                    author.FirstName + " " + author.LastName,
                    author.AuthorsBooks.Count));
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