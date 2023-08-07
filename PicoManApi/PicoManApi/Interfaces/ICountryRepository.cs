using PicoManApi.Models;

namespace PicoManApi.Interfaces
{
    public interface ICountryRepository
    {
        public ICollection<Country> GetCountries();
    }
}
