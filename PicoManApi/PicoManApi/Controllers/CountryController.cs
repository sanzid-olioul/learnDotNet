
using Microsoft.AspNetCore.Mvc;
using PicoManApi.Interfaces;
using PicoManApi.Models;
namespace PicoManApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        public CountryController(ICountryRepository countryRepository) {
            _countryRepository = countryRepository;
  
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
        public IActionResult GetCountries()
        {
            var countries = _countryRepository.GetCountries();
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(countries);
        }
    }
}
