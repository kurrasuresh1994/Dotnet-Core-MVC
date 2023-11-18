using Core.BookStore.Models;
using Core.BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Core.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository;

        public BookController()
        {
            _bookRepository = new BookRepository();
        }
        public ViewResult GetAllBooks()
        {
            var data = _bookRepository.GetAllBooks();
            return View(data);
        }

        public ViewResult GetBook(int id)
        {
            var data = _bookRepository.GetBook(id);
            return View(data);
        }

        public List<BookModel> SearchBook(string title, string author)
        {
            return _bookRepository.SearchBook(title, author);
        }

        public ViewResult AddNewBook()
        {
            return View();
        }

        [HttpPost]
        public ViewResult AddNewBook(BookModel bookModel)
        {
            return View();
        }

    }
}
