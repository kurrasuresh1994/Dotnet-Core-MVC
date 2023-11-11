namespace Core.BookStore.Models.Repository
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

        public List<BookModel> SearchBook(string title,string author)
        {
            return DataSource().Where(x=>x.Title.Contains(title) || x.Author.Contains(author)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1,Title="MVC",Author="Suresh"},
                new BookModel(){Id=2,Title="C#",Author="Ramya"},
                new BookModel(){Id=3,Title="ASP.NET",Author="Raj"},
                new BookModel(){Id=4,Title="WEB SERVICES",Author="Ramesh"},
                new BookModel(){Id=5,Title="WEBAPI",Author="Kurra"},
                 new BookModel(){Id=6,Title="DOTNET CORE",Author="Suresh"},
            };
        }
    }
}
