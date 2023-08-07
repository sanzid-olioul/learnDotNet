using PicoManApi.Data;
using PicoManApi.Interfaces;
using PicoManApi.Models;

namespace PicoManApi.Repository
{
    public class PokemonCategoryRepository:IPokemonCategoryRepository
    {
        private readonly DataContext _context;
        public PokemonCategoryRepository(DataContext context)
        {
                _context = context;
        }
        public ICollection<PokemonCategory> GetPokemonCategories()
        {
            return _context.PokemonCategorys.OrderBy(c => c.CategoryId).ToList();
        }
    }
}
