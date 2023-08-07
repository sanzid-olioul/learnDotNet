using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PicoManApi.Dto;
using PicoManApi.Interfaces;
using PicoManApi.Models;

namespace PicoManApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController:Controller
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            
            var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemons);
        }
 
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int id)
        {
            var pokemon = _mapper.Map <PokemonDto >(_pokemonRepository.GetPokemon(id));
            System.Console.WriteLine(pokemon.Name);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemon);
        }
        [HttpGet("name/{name}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(400)] 
        public IActionResult GetPokemon(string name)
        {
            var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(name));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemon);
        }

        [HttpGet("{PokemonId}/rating")]
        [ProducesResponseType(200,Type = typeof(double))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int PokemonId)
        {
            var ratings = _pokemonRepository.GetPokemonRating(PokemonId);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(ratings);
        }
    }
}
