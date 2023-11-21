using Core.BookStore.Data;
using Core.BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.BookStore.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly BookStoreContext _context;

        public LanguageRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<List<LanguageModel>> GetAllLanguages()
        {
            return await _context.Language.Select(x => new LanguageModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToListAsync();
        }
    }
}
