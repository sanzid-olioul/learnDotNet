using Microsoft.AspNetCore.Mvc;
using PicoManApi.Interfaces;
using PicoManApi.Models;
namespace PicoManApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonCategoryController : Controller
    {
        private readonly IPokemonCategoryRepository _pokemonCategoryRepository;
        public PokemonCategoryController(IPokemonCategoryRepository pokemonCategoryRepository) {
        
            _pokemonCategoryRepository = pokemonCategoryRepository;
        }
        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<PokemonCategory>))]
        public IActionResult GetPokemonCategories()
        {
           var pokemonCategories = _pokemonCategoryRepository.GetPokemonCategories();
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(pokemonCategories);


        }
    }
}
