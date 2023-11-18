using Core.BookStore.Data;
using Core.BookStore.Repository;
using Microsoft.EntityFrameworkCore;

namespace Core.BookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add Services which is required by the application
            builder.Services.AddDbContext<BookStoreContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("conn"))
            );
            builder.Services.AddControllersWithViews();
#if DEBUG
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
#endif
            builder.Services.AddScoped<IBookRepository, BookRepository>();

            //Add middlewares(http request handling pipeline)
            var app = builder.Build();

            app.UseStaticFiles();
            // app.MapGet("/", () => "Hello World!");
            app.MapDefaultControllerRoute();
            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "bookapp/{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}