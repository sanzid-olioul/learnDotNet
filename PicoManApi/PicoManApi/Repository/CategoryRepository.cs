using PicoManApi.Data;
using PicoManApi.Interfaces;
using PicoManApi.Models;
namespace PicoManApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;
        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Category> GetCategories()
        {

            return _context.Categories.OrderBy(p => p.Id).ToList();

        }

        public Category GetCategory(int id)
        {

            return _context.Categories.Where(c=> c.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategorys.Where(e=> e.CategoryId == categoryId).Select(c => c.Pokemon).ToList();
        }

        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c=> c.Id == id);
        }
    }
}
