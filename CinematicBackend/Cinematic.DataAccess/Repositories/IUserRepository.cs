using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cinematic.DataAccess.Entities;

namespace Cinematic.DataAccess.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User Get(Guid id);
        void Delete(Guid userId);
        bool UserExists(string username);
        User Login(string username, string password);
        User Register(User user, string password);
    }
}