using Core.BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Core.BookStore.Controllers
{
    [Route("[controller]/[action]")] //Token replacement
    public class HomeController : Controller
    {
        [Route("~/")]
        public ViewResult Index()
        {
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
