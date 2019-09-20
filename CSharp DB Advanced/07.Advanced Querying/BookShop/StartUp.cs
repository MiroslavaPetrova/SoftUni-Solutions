namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var context = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(context);

                //1.var result = GetBooksByAgeRestriction(context, "miNor");
                //2.var result = GetGoldenBooks(context);
                //3.var result = GetBooksByPrice(context);
                //4.var result = GetBooksNotReleasedIn(context, 2000);
                //5.var result = GetBooksByCategory(context, "horror mystery drama");
                //6.var result = GetBooksReleasedBefore(context, "12-04-1992");
                //7.var result = GetAuthorNamesEndingIn(context, "e");
                //8.var result = GetBookTitlesContaining(context, "WOR");
                //9.var result = GetBooksByAuthor(context, "PO");
                //10.var result = CountBooks(context, 40);
                //11.var result = CountCopiesByAuthor(context);
                //12.var result = GetTotalProfitByCategory(context);
                //13.var result = GetMostRecentBooks(context);
                //14.IncreasePrices(context);
                //15.var result = RemoveBooks(context);
                var result = GetAuthorWithAllHisBooksAndCategories(context);
                Console.WriteLine(result);
            }
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var ageRestrictionCommand = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Where(b => b.AgeRestriction == ageRestrictionCommand)
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToList();

            var result = string.Join(Environment.NewLine, books);

            return result;
        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            var titles = context.Books
                .OrderBy(b => b.BookId)
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .Select(b => b.Title)
                .ToList();

            var result = string.Join(Environment.NewLine, titles);

            return result;
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            var titlesAndPrices = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    Title = b.Title,
                    Price = b.Price
                })
                .OrderByDescending(p => p.Price)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var book in titlesAndPrices)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var bookTitles = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            var result = string.Join(Environment.NewLine, bookTitles);
            return result;
        }
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input
                     .ToLower()
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                     .ToArray();

            var bookTitles = context.Books
                            .Where(b => b.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
                            .Select(t => t.Title)
                            .OrderBy(t => t)
                            .ToList();

            string result = string.Join(Environment.NewLine, bookTitles);

            return result;
        }
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var targetDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate.Value < targetDate)
                .OrderByDescending(b => b.ReleaseDate.Value)
                .Select(b => new
                {
                    Title = b.Title,
                    EditionType = b.EditionType,
                    Price = b.Price
                })
                .ToList();

            string result = string.Join(Environment.NewLine, books.Select(b => $"{b.Title} - {b.EditionType} - ${b.Price:F2}"));
            return result;

            //StringBuilder sb = new StringBuilder();

            //foreach (var book in books)
            //{
            //    sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            //}

            //return sb.ToString().TrimEnd();
        }
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authorNames = context.Authors
                .Where(a => EF.Functions.Like(a.FirstName, $"%{input}")) //a.FirstName.ToLower().EndsWith(input.ToLower()))   
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName
                })
                .OrderBy(a => a.FullName)
                .ToList();

            string result = string.Join(Environment.NewLine, authorNames.Select(a => $"{a.FullName}"));
            return result;
        }
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            return string.Join(Environment.NewLine, context.Books
                .Where(b => EF.Functions.Like(b.Title, $"%{input}%"))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList());
        }
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var booksAuthors = context.Books
                .Where(b => EF.Functions.Like(b.Author.LastName, $"{input}%"))
                .Select(b => new
                {
                    BookTitle = b.Title,
                    AuthorName = b.Author.FirstName + " " + b.Author.LastName,
                    BookId = b.BookId
                })
                .OrderBy(b => b.BookId)
                .ToList();

            var result = string.Join(Environment.NewLine,
                booksAuthors.Select(b => $"{b.BookTitle} ({b.AuthorName})"));

            return result;
        }
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books
                .Count(b => b.Title.Length > lengthCheck);
        }
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var bookCopies = context.Authors
                .Select(a => new
                {
                    BookCpoies = a.Books.Sum(b => b.Copies),
                    AuthorName = a.FirstName + " " + a.LastName
                })
                .OrderByDescending(a => a.BookCpoies)
                .ToList();

            string result = string.Join(Environment.NewLine, bookCopies.Select(a => $"{a.AuthorName} - {a.BookCpoies}"));

            return result;
        }
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var category = context.Categories
                .Select(c => new
                {
                    TotalProfit = c.CategoryBooks.Sum(b => b.Book.Copies * b.Book.Price),
                    CategoryName = c.Name
                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.CategoryName)
                .ToList();

            string result = string.Join(Environment.NewLine, category.Select(c => $"{c.CategoryName} ${c.TotalProfit:F2}"));

            return result;
        }
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    CategoryName = c.Name,
                    AllBooks = c.CategoryBooks
                    .Select(b => new
                    {
                        BookTitle = b.Book.Title,
                        BookReleaseDate = b.Book.ReleaseDate,
                    }).OrderByDescending(b => b.BookReleaseDate)
                    .Take(3)
                    .ToList()
                })
                .OrderBy(c => c.CategoryName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.CategoryName}");

                foreach (var book in category.AllBooks)
                {
                    sb.AppendLine($"{book.BookTitle} ({book.BookReleaseDate.Value.Year})");
                }
            }
            return sb.ToString().TrimEnd();
        }
        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in books)
            {
                book.Price += 5;
                
            }
            context.SaveChanges();
        }
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.Books.RemoveRange(books);
            context.SaveChanges();

            return books.Count();
        }
        public static string GetAuthorWithAllHisBooksAndCategories(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,             //Many <=> BookCategories in the PLURAL
                    AllBooks = a.Books.SelectMany(bc => bc.BookCategories.Select(b => new
                    {
                        BookTitle = b.Book.Title, // Here we are in the mapping and can access either Book or Category
                        BookPrice = b.Book.Price,
                        BookEditionType = b.Book.EditionType,
                        CategoryName  = b.Category.Name
                    }))
                })
                .OrderBy(a => a.FirstName)
                .ToList();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName}");

                foreach (var book in author.AllBooks)
                {
                    sb.AppendLine($"{book.CategoryName} {book.BookEditionType} {book.BookTitle} {book.BookPrice}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
