using Microsoft.AspNetCore.Mvc;
using PicoManApi.Interfaces;
using PicoManApi.Models;
namespace PicoManApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonOwnerController : Controller
    {
        private readonly IPokemonOwnerRepository _pokemonOwnerRepository;
        public PokemonOwnerController(IPokemonOwnerRepository pokemonOwnerRepository)
        {
            _pokemonOwnerRepository = pokemonOwnerRepository;
        }
        [HttpGet]
        [ProducesResponseType(200,Type =typeof(IEnumerable<PokemonOwner>))]
        public IActionResult GetpokemonOwners()
        {
            var pokemonOwners = _pokemonOwnerRepository.GetPokemonOwners();
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            return  Ok(pokemonOwners);
        }
    }
}
