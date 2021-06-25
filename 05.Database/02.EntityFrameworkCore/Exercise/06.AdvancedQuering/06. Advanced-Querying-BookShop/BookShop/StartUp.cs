namespace BookShop
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Globalization;
    using Microsoft.EntityFrameworkCore.SqlServer;

    using Data;
    //using Initializer;
    using Models.Enums;

    public class StartUp
    {
        public static void Main()
        {
            using var context = new BookShopContext();
            //DbInitializer.ResetDatabase(context);

            //var ageRestriction = Console.ReadLine();
            //var year = int.Parse(Console.ReadLine());
            //var input = Console.ReadLine();
            //var date = Console.ReadLine();
            //var input = Console.ReadLine();
            //var input = Console.ReadLine();
            //var input = Console.ReadLine();
            //var lengthCheck = int.Parse(Console.ReadLine());

            //var booksByAgeRestriction = GetBooksByAgeRestriction(context, ageRestriction);
            //var goldenBooks = GetGoldenBooks(context);
            //var expensiveBooks = GetBooksByPrice(context);
            //var bookNotInYear = GetBooksNotReleasedIn(context, year);
            //var bookByCategories = GetBooksByCategory(context, input);
            //var bookBeforeDate = GetBooksReleasedBefore(context, date);
            //var authorsByNameEnding = GetAuthorNamesEndingIn(context, input);
            //var bookTitlesWithGivenString = GetBookTitlesContaining(context, input);
            //var booksByAuthor = GetBooksByAuthor(context, input);
            //var booksWithTitleLength = CountBooks(context, lengthCheck);
            //var authorsWithBookTitleCount = CountCopiesByAuthor(context);
            //var profitByCategories = GetTotalProfitByCategory(context);
            //var mostRecentBooks = GetMostRecentBooks(context);

            //Console.WriteLine(mostRecentBooks);

            //IncreasePrices(context);
            Console.WriteLine(RemoveBooks(context));
        }

        //Problem 01
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var books = context.Books
                .Where(x => x.AgeRestriction == Enum.Parse<AgeRestriction>(command, true))
                .OrderBy(x => x.Title)
                .Select(x => x.Title)
                .AsEnumerable();

            var output = string.Join(Environment.NewLine, books);

            return output;
        }

        //Problem 02
        public static string GetGoldenBooks(BookShopContext context)
        {
            var goldenBook = context.Books
                .Where(x => x.Copies < 5000 && x.EditionType == EditionType.Gold)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();

            var output = string.Join(Environment.NewLine, goldenBook);

            return output;
        }

        //Problem 03
        public static string GetBooksByPrice(BookShopContext context)
        {
            var expensiveBooks = context.Books
                .Where(x => x.Price > 40)
                .OrderByDescending(x => x.Price)
                .Select(x => $"{x.Title} - ${x.Price:F2}")
                .ToList();

            var output = string.Join(Environment.NewLine, expensiveBooks);

            return output;
        }

        //Problem 04
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var booksNotInYear = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .AsEnumerable();

            var output = string.Join(Environment.NewLine, booksNotInYear);

            return output;
        }

        //Problem 05
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input
                .Split()
                .Select(x => x.ToLower())
                .ToList();

            var bookByCategories = context.Categories
                .Where(x => categories.Contains(x.Name.ToLower()))
                .SelectMany(x => x.CategoryBooks.Select(x => x.Book.Title))
                .OrderBy(x => x)
                .ToList();

            var output = string.Join(Environment.NewLine, bookByCategories);

            return output;
        }

        //Problem 06
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var compareDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var booksBeforeReleaseDate = context.Books
                .Where(x => x.ReleaseDate < compareDate)
                .OrderByDescending(x => x.ReleaseDate)
                .Select(x => $"{x.Title} - {x.EditionType} - ${x.Price:F2}")
                .ToList();

            var output = string.Join(Environment.NewLine, booksBeforeReleaseDate);

            return output;
        }

        //Problem 07
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorByNameEnding = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .Select(x => $"{x.FirstName} {x.LastName}")
                .ToList();

            var output = string.Join(Environment.NewLine, authorByNameEnding);

            return output;
        }

        //Problem 08
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var bookTitleContainingString = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title)
                .OrderBy(x => x)
                .ToList();

            var output = string.Join(Environment.NewLine, bookTitleContainingString);

            return output;
        }

        //Problem 09
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var bookByAuthors = context.Books
                .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(x => x.BookId)
                .Select(x => $"{x.Title} ({x.Author.FirstName} {x.Author.LastName})")
                .AsEnumerable();

            var output = string.Join(Environment.NewLine, bookByAuthors);

            return output;
        }

        //Problem 10
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var countOfBooksWithTitleLength = context.Books
                .Count(x => x.Title.Length > lengthCheck);

            return countOfBooksWithTitleLength;
        }

        //Problem 11
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authorsWithBookCount = context.Authors
                .Select(x => new 
                {
                    x.FirstName,
                    x.LastName,
                    BookCopies =  x.Books.Sum(x => x.Copies)
                })
                .OrderByDescending(x => x.BookCopies)
                .Select(x => $"{x.FirstName} {x.LastName} - {x.BookCopies}")
                .AsEnumerable();

            var output = string.Join(Environment.NewLine, authorsWithBookCount);

            return output;
        }

        //Problem 12
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var profitByCategories = context.Categories
                .Select(x => new
                {
                    x.Name,
                    TotalProfit = x.CategoryBooks.Sum(x => x.Book.Price * x.Book.Copies)
                })
                .OrderByDescending(x => x.TotalProfit)
                .ThenBy(x => x.Name)
                .AsEnumerable();

            var output = string.Join(Environment.NewLine, profitByCategories
                .Select(x => $"{x.Name} ${x.TotalProfit:F2}"));

            return output;
        }

        //Problem 13
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var mostRecentBooks = context.Categories
                .Select(x => new
                {
                    x.Name,
                    RecentBooks = x.CategoryBooks
                        .OrderByDescending(x => x.Book.ReleaseDate)
                        .Select(x => new
                        {
                            x.Book.Title,
                            x.Book.ReleaseDate.Value.Year
                        })
                        .Take(3)
                })
                .OrderBy(x => x.Name)
                .AsEnumerable();

            var sb = new StringBuilder();

            foreach (var categoty in mostRecentBooks)
            {
                sb.AppendLine($"--{categoty.Name}");

                foreach (var book in categoty.RecentBooks)
                {
                    sb.AppendLine($"{book.Title} ({book.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 14
        public static void IncreasePrices(BookShopContext context)
        {
            var booksToIncrease = context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .AsEnumerable();

            foreach (var book in booksToIncrease)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        //Problem 15
        public static int RemoveBooks(BookShopContext context)
        {
            var bookCategoriesToDelete = context.BooksCategories
                .Where(x => x.Book.Copies < 4200)
                .AsEnumerable();

            foreach (var book in bookCategoriesToDelete)
            {
                context.BooksCategories.Remove(book);
            }

            context.SaveChanges();

            var booksToRemove = context.Books
                .Where(x => x.Copies < 4200)
                .AsEnumerable();

            foreach (var book in booksToRemove)
            {
                context.Books.Remove(book);
            }

            var count = context.SaveChanges();

            return count;
        }
    }
}
