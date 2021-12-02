namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

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

            var xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Books";
            var serializer = new XmlSerializer(typeof(BookImportModel[]), xRoot);
            var booksDto = (BookImportModel[])serializer.Deserialize(new StringReader(xmlString));

            var books = new List<Book>();

            foreach (var book in booksDto)
            {
                if (!IsValid(book))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                DateTime publishedOn;
                var isValidDate = DateTime.TryParseExact(book.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out publishedOn);

                if (!isValidDate)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var bookDb = new Book
                {
                    Name = book.Name,
                    Genre = (Genre)book.Genre,
                    Price = book.Price,
                    Pages = book.Pages,
                    PublishedOn = publishedOn
                };

                books.Add(bookDb);
                sb.AppendLine($"Successfully imported book {bookDb.Name} for {bookDb.Price:f2}.");
            }

            context.Books.AddRange(books);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var authorsDto = JsonConvert.DeserializeObject<AuthorImportModel[]>(jsonString);

            var authors = new List<Author>();

            foreach (var author in authorsDto)
            {
                if (!IsValid(author))
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var email = authors.FirstOrDefault(x=>x.Email == author.Email);
                
                if (email != null)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                var authorDb = new Author
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    Email = author.Email,
                    Phone = author.Phone,
                };

   
                foreach (var book in author.Books)
                {
                    var currBook = context.Books.FirstOrDefault(x => x.Id == book.Id);
                    if (currBook == null)
                    {
                        continue;                             
                    }
                    var authorBook = new AuthorBook
                    {
                        Author = authorDb,
                        Book = currBook,
                    };

                    authorDb.AuthorsBooks.Add(authorBook);
                }
                if (authorDb.AuthorsBooks.Count == 0)
                {
                    sb.AppendLine("Invalid data!");
                    continue;
                }

                authors.Add(authorDb);
                sb.AppendLine($"Successfully imported author - {authorDb.FirstName} {authorDb.LastName} with {authorDb.AuthorsBooks.Count} books.");
            }

            context.Authors.AddRange(authors);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}