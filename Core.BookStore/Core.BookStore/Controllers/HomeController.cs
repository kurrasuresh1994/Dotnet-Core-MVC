using Core.BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Core.BookStore.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ViewData["prop"] = "Kurra Suresh";
            ViewData["book"]=new BookModel() { Id = 1,Author="testauthor" };
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
