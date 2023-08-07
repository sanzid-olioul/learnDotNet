using Microsoft.AspNetCore.Mvc;
using PicoManApi.Interfaces;
using PicoManApi.Models;
namespace PicoManApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : Controller
    {
        private readonly IReviewerRepository _reviewerRepository;
        public ReviewerController(IReviewerRepository reviewerRepository)
        {
            _reviewerRepository = reviewerRepository;
        }
        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Reviewer>))]
        public IActionResult GetReviewers()
        {
            var reviewers = _reviewerRepository.GetReviewers();
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(reviewers);
        }
    }
}
