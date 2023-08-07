using Microsoft.AspNetCore.Mvc;
using PicoManApi.Interfaces;
using PicoManApi.Models;
namespace PicoManApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewController(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Review>))]
        public IActionResult GetReviews()
        {
            var reviews = _reviewRepository.GetReviews();

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(reviews);
        }
    }
}
