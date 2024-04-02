using DataObjectLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly LibraryDbContext _LibraryDbContext;
        public UserRepository(LibraryDbContext libraryDbContext)
        {
            _LibraryDbContext = libraryDbContext;
        }
        public void Add(User user)
        {
            _LibraryDbContext.Add(user);
        }

        public List<User> GetUsers()
        {
            return _LibraryDbContext.Users.ToList();
        }

        public void SaveChanges()
        {
            _LibraryDbContext.SaveChanges();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _LibraryDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateUser(int id,int token)
        {
            var _user = await GetUserById(id);
            _user.Tokens_Available = token;
            _LibraryDbContext.SaveChanges();
        }
    }
}
