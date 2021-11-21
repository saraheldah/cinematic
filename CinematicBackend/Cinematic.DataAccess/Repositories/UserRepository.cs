using System;
using System.Collections.Generic;
using System.Linq;
using Cinematic.DataAccess.Entities;

namespace Cinematic.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        static List<User> _users;

        public UserRepository()
        {
            if (_users == null)
            {
                _users = new List<User>();
            }
        }
        
        public List<User> GetAll()
        {
            return _users;
        }

        public User Get(int id)
        {
            // return _users.Find(id);
            return _users.SingleOrDefault(x => x.Id == id);
        }

        public User Add(User user)
        {
            // _users.Insert(user);
            _users.Add(user);
            return user;
        }

        public void Delete(User user)
        {
            _users.Remove(user);
        }

        public void Update(int id, User newUser)
        {
            var updatedUser = _users.SingleOrDefault(x => x.Id == id);
            updatedUser.Email = newUser.Email;
            updatedUser.Password = newUser.Password;
            updatedUser.Phone = newUser.Phone;
        }
    }
}