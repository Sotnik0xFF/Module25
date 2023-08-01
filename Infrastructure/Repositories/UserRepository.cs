using Module25.Domain.BookAggregate;
using Module25.Domain.Common;
using Module25.Domain.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module25.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ELibContext _context;

        public UserRepository(ELibContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Add(User entity)
        {
            _context.Users.Add(entity);
        }

        public void Delete(User entity)
        {
            _context.Users.Remove(entity);
        }

        public User? Get(int id)
        {
            User? user = _context.Users.Find(id);
            if (user != null)
            {
                LoadData(user);
            }
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            List<User> users = _context.Users.ToList();
            foreach (var user in users)
            {
                LoadData(user);
            }
            return users;
        }

        public bool IsOwned(Book book)
        {
            User? user = _context.Users.FirstOrDefault(u => u.Books.Contains(book));
            return user != null;
        }

        public void UpdateName(int id, string name)
        {
            User? user = Get(id);
            if (user == null)
                throw new ArgumentException("Id not found.", nameof(id));
            user.Name = name;
            _context.SaveChanges();
        }

        private void LoadData(User user)
        {
            _context.Entry(user).Collection(u => u.Books).Load();
        }
    }
}
