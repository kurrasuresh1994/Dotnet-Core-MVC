using Core.BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Core.BookStore.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ViewResult Index()
        {
            var result = _configuration["AppName"];
            var key1 = _configuration["infoObj:key1"];
            var key2 = _configuration["infoObj:key2"];
            var key3 = _configuration["infoObj:key3:key3obj"];
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

        [Route("test/a{a}")]
        public string Test(string a)
        {
            return a;
        }

        [Route("test/b{a}")]
        public string Test1(string a)
        {
            return a;
        }

        [Route("test/c{a}")]
        public string Test2(string a)
        {
            return a;
        }
    }
}
