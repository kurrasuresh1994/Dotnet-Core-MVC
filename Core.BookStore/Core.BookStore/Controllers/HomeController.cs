using Core.BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Core.BookStore.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ViewBag.Title = "Suresh";

            dynamic data = new ExpandoObject();
            data.Id = 1;
            data.Name = "Suresh";
            ViewBag.Data = data;
            ViewBag.Type=new BookModel() { Author="TestAuthor",Id=6};
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
