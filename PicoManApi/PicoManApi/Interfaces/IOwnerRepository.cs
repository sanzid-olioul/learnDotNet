using PicoManApi.Models;

namespace PicoManApi.Interfaces
{
    public interface IOwnerRepository
    {
        public ICollection<Owner> GetOwners();
    }
}
