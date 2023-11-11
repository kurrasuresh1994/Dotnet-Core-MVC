namespace Core.BookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add Services which is required by the application
            builder.Services.AddControllersWithViews();


            var app = builder.Build();

            app.UseStaticFiles();
            // app.MapGet("/", () => "Hello World!");
            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}