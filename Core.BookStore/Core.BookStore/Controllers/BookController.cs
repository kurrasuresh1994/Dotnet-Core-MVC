using Core.BookStore.Models;
using Core.BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Core.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }

        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBook(id);
            return View(data);
        }

        public List<BookModel> SearchBook(string title, string author)
        {
            return _bookRepository.SearchBook(title, author);
        }

        public ViewResult AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            var book = new BookModel()
            {
                Language = "Telugu"
            };

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                var id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }
            ModelState.AddModelError("", "This is custom error message");
            return View();
        }

    }
}
