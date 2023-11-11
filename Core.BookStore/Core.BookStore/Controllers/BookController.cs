using Core.BookStore.Models;
using Core.BookStore.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Core.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository=null;

        public BookController()
        {
            _bookRepository = new BookRepository();
        }
        public ViewResult GetAllBooks()
        {
            var data= _bookRepository.GetAllBooks();
            return View(data);
        }

        public BookModel GetBook(int id)
        {
            return _bookRepository.GetBook(id);
        }

        public List<BookModel> SearchBook(string title,string author)
        {
            return _bookRepository.SearchBook(title, author);
        }
    }
}
