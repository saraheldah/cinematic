using System;
using System.Collections.Generic;
using Cinematic.DataAccess.Entities;

namespace Cinematic.DataAccess.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User Get(int id);
        User Add(User user);
        void Delete(User user);
        void Update(int id,User newUser);
    }
}