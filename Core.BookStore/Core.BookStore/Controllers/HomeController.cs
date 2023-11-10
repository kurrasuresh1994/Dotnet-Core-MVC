using Microsoft.AspNetCore.Mvc;

namespace Core.BookStore.Controllers
{
    public class HomeController:Controller
    {
        public string Index()
        {
            return "Hello from Home";
        }
    }
}
