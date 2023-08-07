using PicoManApi.Models;

namespace PicoManApi.Interfaces
{
    public interface IPokemonCategoryRepository
    {
        public ICollection<PokemonCategory> GetPokemonCategories();
    }
}
