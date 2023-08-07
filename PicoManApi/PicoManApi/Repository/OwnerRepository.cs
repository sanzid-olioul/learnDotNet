using PicoManApi.Data;
using PicoManApi.Interfaces;
using PicoManApi.Models;

namespace PicoManApi.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;
        public OwnerRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.OrderBy(o => o.Id).ToList();
        }
    }
}
