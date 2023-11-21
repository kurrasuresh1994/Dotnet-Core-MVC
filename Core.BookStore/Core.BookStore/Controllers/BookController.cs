using Core.BookStore.Models;
using Core.BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Dynamic;

namespace Core.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILanguageRepository _languageRepository;

        public BookController(IBookRepository bookRepository, ILanguageRepository languageRepository)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
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

        public async Task<ViewResult> AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.Language = new SelectList(await _languageRepository.GetAllLanguages(), "Id", "Name");
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
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
            ViewBag.Language = new SelectList(await _languageRepository.GetAllLanguages(), "Id", "Name");
            ModelState.AddModelError("", "This is custom error message");
            return View();
        }
    }
}
