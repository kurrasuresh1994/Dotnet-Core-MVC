using Core.BookStore.Models;

namespace Core.BookStore.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetTopBooks(int count);
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBook(int id);
        Task<int> AddNewBook(BookModel bookModel);
    }
}
