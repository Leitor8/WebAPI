using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> Get();
        User Get(int id);
        User Create(User user);
        void Update(User user);
        void Delete(int id);
    }
}
