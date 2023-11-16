using Core.BookStore.Models;

namespace Core.BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBook(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string title, string author)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(author)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1,Title="MVC",Author="Suresh",Description="This is the description for MVC book",Category="Framework",Language="English",TotalPages=100},
                new BookModel(){Id=2,Title="C#",Author="Ramya",Description="This is the description for C# book",Category="Developer",Language="Spanish",TotalPages=200},
                new BookModel(){Id = 3, Title = "ASP.NET", Author = "Raj", Description = "This is the description for ASP.NET book", Category = "Concept", Language = "Chinise", TotalPages = 200},
                new BookModel(){Id = 4, Title = "WEB SERVICES", Author = "Ramesh", Description = "This is the description for WEB SERVICE book", Category = "Concept", Language = "English", TotalPages = 150},
                new BookModel(){Id = 5, Title = "WEBAPI", Author = "Kurra", Description = "This is the description for WEB API book", Category = "Concept", Language = "Hindi", TotalPages = 110},
                new BookModel(){Id = 6, Title = "DOTNET CORE", Author = "Suresh", Description = "This is the description for DOTNET CORE book", Category = "Framework", Language = "Telugu", TotalPages = 250},
            };
        }
    }
}
