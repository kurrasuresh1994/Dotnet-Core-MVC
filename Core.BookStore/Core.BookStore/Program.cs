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
            //UnComment this code to disable client side validation
            //.AddViewOptions(options =>
            //{
            //    options.HtmlHelperOptions.ClientValidationEnabled = false;
            //});
#endif
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<ILanguageRepository, LanguageRepository>();

            //Add middlewares(http request handling pipeline)
            var app = builder.Build();

            app.UseStaticFiles();
            // app.MapGet("/", () => "Hello World!");
            app.UseRouting();
            // app.MapControllers();
            app.MapDefaultControllerRoute();
            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");

            //Conventional routing
            //app.MapControllerRoute(
            //    name: "Aboutus",
            //    pattern: "About-us/{id?}",
            //    defaults: new { controller = "Home", Action = "Aboutus" });
            app.Run();
        }
    }
}