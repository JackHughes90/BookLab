using System.Linq;
using BookLab.Models.Database;

namespace BookLab.Repositories
{
    public interface IUserRepo
    {
        User GetByUsername(string username);
        User Create(User newUser);
    }

    public class UserRepo : IUserRepo
    {
        private readonly BookLabDbContext _context;

        public UserRepo(BookLabDbContext context)
        {
            _context = context;
        }

        public User GetByUsername(string username)
        {
            return _context.Users.Single(user => user.Username == username);
        }

        public User Create(User newUser)
        {
            var insertResponse = _context.Users.Add(newUser);

            _context.SaveChanges();

            return insertResponse.Entity;
        }
    }
}
