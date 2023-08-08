using Microsoft.AspNetCore.Mvc;
using OnlyOne.Interface;
using OnlyOne.Models;

namespace OnlyOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController:Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(users);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        public IActionResult GetUser(int id)
        {
            var user = _userRepository.GetUser(id);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            return Ok(user);
        }
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult CreateUser(User user) 
        { 
            _userRepository.CreateUser(user);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok("Created");
        }
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            if(!_userRepository.UpdateUser(user))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(int id)
        {
            var user = _userRepository.GetUser(id);
            _userRepository.DeleteUser(user);
            return Ok("Deleted");
        }

    }
}
