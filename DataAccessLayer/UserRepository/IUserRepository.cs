using DataObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UserRepository
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        void Add(User user);
        void SaveChanges();
        Task<User> GetUserById(int Id);
        Task UpdateUser(int id, int token);
    }
}
