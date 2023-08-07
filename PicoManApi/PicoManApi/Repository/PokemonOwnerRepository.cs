using PicoManApi.Data;
using PicoManApi.Interfaces;
using PicoManApi.Models;

namespace PicoManApi.Repository
{

    public class PokemonOwnerRepository: IPokemonOwnerRepository
    {
        private readonly DataContext _context;
        public PokemonOwnerRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<PokemonOwner> GetPokemonOwners()
        {
            return _context.PokemonOwners.OrderBy(po => po.OwnerId).ToList();
        }
    }
}
