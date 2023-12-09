using Core.BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Core.BookStore.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult AboutUs(int id, string name)
        {
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
