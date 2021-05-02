using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repositories
{
    public class MemoryUserRepository : IUserRepository
    {
        public static List<User> memoryUsers = new List<User> { };
        public User Create(User user)
        {
            user.Id = memoryUsers.Count;
            memoryUsers.Add(user);
            return user;
        }

        public void Delete(int id)
        {
            foreach(User a in memoryUsers)
            {
                if(a.Id == id)
                {
                    memoryUsers.Remove(a);
                }
            }
        }

        public IEnumerable<User> Get()
        {
            return memoryUsers;
        }

        public User Get(int id)
        {
            foreach(User a in memoryUsers)
            {
                if(a.Id == id)
                {
                    return a;
                }
            }
            return null;
        }

        public void Update(User user)
        {
            foreach(User a in memoryUsers)
            {
                if(a.Id == user.Id)
                {
                    a.Email = user.Email;
                    a.CPF = user.CPF;
                    a.DataNascimento = user.DataNascimento;
                    a.Nome = user.Nome;
                    a.Telefone = user.Telefone;
                }
            }
        }
    }
}
