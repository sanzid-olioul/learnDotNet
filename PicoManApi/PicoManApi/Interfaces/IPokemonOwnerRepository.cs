using PicoManApi.Models;

namespace PicoManApi.Interfaces
{
    public interface IPokemonOwnerRepository
    {
        public ICollection<PokemonOwner> GetPokemonOwners();
    }
}
