using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using OnlyOne.Data;
using OnlyOne.Interface;
using OnlyOne.Models;

namespace OnlyOne.Repository
{
    public class UserRepository:IUserRepository
    {
        DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public bool CreateUser(User user)
        {
            _context.Add(user);

            return Save();
        }

        public bool DeleteUser(User user)
        {
            _context.Remove(user);
            return Save();
        }

        public User GetUser(int id)
        {
            return _context.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public bool UpdateUser(User user)
        {
           
            _context.Update(user);
            return Save();
        }

        public bool UserExists(int id)
        {
            return _context.Users.Any(u=> u.Id == id);
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
