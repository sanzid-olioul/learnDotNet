using OnlyOne.Models;

namespace OnlyOne.Interface
{
    public interface IUserRepository
    {
        public ICollection<User> GetUsers();
        public User GetUser(int id);
        public bool CreateUser(User user);
        public bool UpdateUser(User user);
        public bool DeleteUser(User user);
        public bool UserExists(int id);
        public bool Save();
    }
}
