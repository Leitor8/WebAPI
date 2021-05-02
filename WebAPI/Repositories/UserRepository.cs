using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }
        public User Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void Delete(int id)
        {
            var toDelete = _context.Users.Find(id);
            _context.Users.Remove(toDelete);
            _context.SaveChangesAsync();
        }

        public IEnumerable<User> Get()
        {
            return _context.Users.ToList();
        }

        public  User Get(int id)
        {
            return _context.Users.Find(id);
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
