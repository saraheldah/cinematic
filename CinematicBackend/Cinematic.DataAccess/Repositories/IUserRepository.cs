using System;
using System.Collections.Generic;
using Cinematic.DataAccess.Entities;

namespace Cinematic.DataAccess.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User Get(Guid id);
        void Add(User user);
        void Delete(Guid userId);
        void Update(Guid id,User newUser);
    }
}