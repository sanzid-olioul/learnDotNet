using PicoManApi.Models;

namespace PicoManApi.Interfaces
{
    public interface IReviewerRepository
    {
        public ICollection<Reviewer> GetReviewers();
    }
}
