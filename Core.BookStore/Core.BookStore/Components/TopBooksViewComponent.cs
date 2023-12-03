using Microsoft.AspNetCore.Mvc;

namespace Core.BookStore.Components
{
    public class TopBooksViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
