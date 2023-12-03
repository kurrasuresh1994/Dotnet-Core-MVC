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
                LanguageId = bookModel.LanguageId,
                CoverImageUrl = bookModel.CoverImageUrl,
                BookPdfUrl = bookModel.BookPdfUrl,
            };
            newBook.bookGallery = new List<BookGallery>();
            foreach (var item in bookModel.Gallery)
            {
                newBook.bookGallery.Add(new BookGallery()
                {
                    Name = item.Name,
                    URL = item.URL,
                });
            }
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            return await _context.Books.Select(x =>

                new BookModel()
                {
                    Author = x.Author,
                    Title = x.Title,
                    Description = x.Description,
                    Id = x.Id,
                    TotalPages = x.TotalPages,
                    LanguageId = x.LanguageId,
                    Language = x.Language.Name,
                    Category = x.Category,
                    CoverImageUrl = x.CoverImageUrl,
                    BookPdfUrl = x.BookPdfUrl,
                }
            ).ToListAsync();
        }

        public async Task<BookModel> GetBook(int id)
        {
            return await _context.Books.Where(x => x.Id == id)
                .Select(book => new BookModel()
                {
                    Author = book.Author,
                    Title = book.Title,
                    Id = book.Id,
                    Description = book.Description,
                    TotalPages = book.TotalPages,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    Category = book.Category,
                    CoverImageUrl = book.CoverImageUrl,
                    BookPdfUrl = book.BookPdfUrl,
                    Gallery = book.bookGallery.Select(s => new GalleryModel()
                    {
                        Id = s.Id,
                        Name = s.Name,
                        URL = s.URL,
                    }).ToList(),
                }).FirstOrDefaultAsync();
        }

        public async Task<List<BookModel>> GetTopBooks(int count)
        {
            return await _context.Books.Select(x =>

                new BookModel()
                {
                    Author = x.Author,
                    Title = x.Title,
                    Description = x.Description,
                    Id = x.Id,
                    TotalPages = x.TotalPages,
                    LanguageId = x.LanguageId,
                    Language = x.Language.Name,
                    Category = x.Category,
                    CoverImageUrl = x.CoverImageUrl,
                    BookPdfUrl = x.BookPdfUrl,
                }
            ).Take(count).ToListAsync();
        }
    }
}
