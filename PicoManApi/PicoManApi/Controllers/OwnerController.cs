using Microsoft.AspNetCore.Mvc;
using PicoManApi.Interfaces;
using PicoManApi.Models;
namespace PicoManApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {
        private readonly IOwnerRepository _ownerRepository;
        public OwnerController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Owner>))]
        public IActionResult GetOwners()
        {
            var owners = _ownerRepository.GetOwners();
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(owners);
        }
    }
}
