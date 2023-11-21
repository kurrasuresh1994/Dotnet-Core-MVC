using Core.BookStore.Models;

namespace Core.BookStore.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetAllLanguages();
    }
}
