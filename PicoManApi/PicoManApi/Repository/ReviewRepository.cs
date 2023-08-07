using PicoManApi.Data;
using PicoManApi.Interfaces;
using PicoManApi.Models;

namespace PicoManApi.Repository
{
    public class ReviewRepository:IReviewRepository
    {
        private readonly DataContext _context;
        public ReviewRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Review> GetReviews()
        {
            return _context.Reviews.OrderBy(review => review.Id).ToList();
        }
    }
}
