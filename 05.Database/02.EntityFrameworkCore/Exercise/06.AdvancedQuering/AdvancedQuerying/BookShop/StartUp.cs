namespace BookShop
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models.Enums;

    public class StartUp
    {
        public static void Main()
        {
            using var context = new BookShopContext();

            //var input = Console.ReadLine();
            //var input = int.Parse(Console.ReadLine());

            //var result = CountBooks(context, intInput);
            var result = RemoveBooks(context);
            //IncreasePrices(context);

            Console.WriteLine(result);
        }

        //2. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var output = context.Books
                .Where(b => b.AgeRestriction == Enum.Parse<AgeRestriction>(command, true))
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToList();

            return string.Join(Environment.NewLine, output);
        }

        //3. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            var output = context.Books
                .Where(b => b.EditionType == EditionType.Gold
                         && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, output);
        }

        //4. Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            var output = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => $"{b.Title} - ${b.Price}")
                .ToList();

            return string.Join(Environment.NewLine, output);
        }

        //5. Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var output = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, output);
        }

        //6. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower())
                .ToArray();

            var output = context.Books
                .Where(b => b.BookCategories
                            .Any(bc => categories.Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, output);
        }

        //7. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var dateParts = date
                .Split('-')
                .Select(int.Parse)
                .ToArray();

            var day = dateParts[0];
            var month = dateParts[1];
            var year = dateParts[2];

            var convertDate = new DateTime(year, month, day);

            var output = context.Books
                .Where(b => b.ReleaseDate.Value < convertDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}")
                .ToList();

            return string.Join(Environment.NewLine, output);
        }

        //8. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var output = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => $"{a.FirstName} {a.LastName}")
                .AsEnumerable();

            return string.Join(Environment.NewLine, output);
        }

        //9. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var output = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .AsEnumerable();

            return string.Join(Environment.NewLine, output);
        }

        //10. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var output = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .ToList();

            return string.Join(Environment.NewLine, output);
        }

        //11. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                .Count(b => b.Title.Length > lengthCheck);
        }

        //12. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var output = context.Authors
                .Select(a => new
                {
                    AuthorName = $"{a.FirstName} {a.LastName}",
                    TotalBookCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.TotalBookCopies)
                .Select(a => $"{a.AuthorName} - {a.TotalBookCopies}")
                .ToList();

            return string.Join(Environment.NewLine, output);
        }

        //13. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var output = context.Categories
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks.Sum(cb => cb.Book.Price * cb.Book.Copies)
                })
                .OrderByDescending(cb => cb.TotalProfit)
                .ThenBy(cb => cb.Name)
                .Select(cb => $"{cb.Name} ${cb.TotalProfit}")
                .AsEnumerable();

            return string.Join(Environment.NewLine, output);
        }

        //14. Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var output = context.Categories
                .Select(c => new
                {
                    c.Name,
                    TopThreeMostRecentBooks = c.CategoryBooks
                                               .Select(cb => cb.Book)
                                               .OrderByDescending(b => b.ReleaseDate.Value.Year)
                                               .Select(b => $"{b.Title} ({b.ReleaseDate.Value.Year})")
                                               .Take(3)
                })
                .OrderBy(c => c.Name)
                .Select(c => $"--{c.Name}{Environment.NewLine}{string.Join(Environment.NewLine, c.TopThreeMostRecentBooks)}")
                .AsEnumerable();

            return string.Join(Environment.NewLine, output);
        }

        //15. Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            var year = "2010";
            context.Database
                .ExecuteSqlInterpolated($"UPDATE Books SET Price += 5 WHERE YEAR(ReleaseDate) < {year}");
        }

        //16. Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            var numberOfCopies = 4200;
            var output = context.Database
                .ExecuteSqlInterpolated($"DELETE FROM BOOKS WHERE Copies < {numberOfCopies}");

            return output;
        }
    }
}
