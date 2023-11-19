using Core.BookStore.Data;
using Core.BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.BookStore.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adding new book in books table
        /// </summary>
        /// <param name="bookModel"></param>
        /// <returns></returns>
        public async Task<int> AddNewBook(BookModel bookModel)
        {
            var newBook = new Books()
            {
                Author = bookModel.Author,
                Title = bookModel.Title,
                Description = bookModel.Description,
                CreatedOn = DateTime.UtcNow,
                TotalPages = bookModel.TotalPages.HasValue ? bookModel.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow,
                Language = bookModel.Language
            };
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allBooks = await _context.Books.ToListAsync();
            if (allBooks?.Any() == true)
            {
                foreach (var book in allBooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Title = book.Title,
                        Id = book.Id,
                        Description = book.Description,
                        TotalPages = book.TotalPages,
                        Language = book.Language,
                        Category = book.Category
                    });
                }
            }
            return books;
        }

        public async Task<BookModel> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                var bookDetails = new BookModel()
                {
                    Author = book.Author,
                    Title = book.Title,
                    Id = book.Id,
                    Description = book.Description,
                    TotalPages = book.TotalPages,
                    Language = book.Language,
                    Category = book.Category
                };
                return bookDetails;
            }
            return null;
        }

        public List<BookModel> SearchBook(string title, string author)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(author)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1,Title="MVC",Author="Suresh",Description="This is the description for MVC book",Category="Framework",Language="English",TotalPages=100},
                new BookModel(){Id=2,Title="C#",Author="Ramya",Description="This is the description for C# book",Category="Developer",Language="Spanish",TotalPages=200},
                new BookModel(){Id = 3, Title = "ASP.NET", Author = "Raj", Description = "This is the description for ASP.NET book", Category = "Concept", Language = "Chinise", TotalPages = 200},
                new BookModel(){Id = 4, Title = "WEB SERVICES", Author = "Ramesh", Description = "This is the description for WEB SERVICE book", Category = "Concept", Language = "English", TotalPages = 150},
                new BookModel(){Id = 5, Title = "WEBAPI", Author = "Kurra", Description = "This is the description for WEB API book", Category = "Concept", Language = "Hindi", TotalPages = 110},
                new BookModel(){Id = 6, Title = "DOTNET CORE", Author = "Suresh", Description = "This is the description for DOTNET CORE book", Category = "Framework", Language = "Telugu", TotalPages = 250},
            };
        }
    }
}
