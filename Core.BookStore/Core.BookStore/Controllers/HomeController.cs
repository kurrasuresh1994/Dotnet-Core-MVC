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

        [Route("about-us",Name ="about-us")]
        [HttpGet]
        public ViewResult AboutUs(int id)
        {
            return View();
        }

        [HttpGet("contact-us")]
        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
