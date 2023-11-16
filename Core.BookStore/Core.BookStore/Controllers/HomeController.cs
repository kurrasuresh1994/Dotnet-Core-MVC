using Core.BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Core.BookStore.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public string? CustomProp { get; set; }

        [ViewData]
        public string? Title { get; set; }

        [ViewData]
        public BookModel? Book { get; set; }

        public ViewResult Index()
        {
            CustomProp = "Custom value";
            Title = "Home Controller - Index";
            Book = new BookModel() { Id=1, Title="Test Title"};
            return View();
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
