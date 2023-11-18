using Core.BookStore.Models;

namespace Core.BookStore.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBook(int id);
        List<BookModel> SearchBook(string title, string author);
        Task<int> AddNewBook(BookModel bookModel);
    }
}
