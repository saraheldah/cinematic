using System;
using System.Collections.Generic;
using Cinematic.Business.DTO;
using Cinematic.Common;
using Cinematic.DataAccess.Entities;

namespace Cinematic.Business.Managers
{
    public interface IUserManager
    {
        List<UserDTO> GetAll();
        UserDTO Get(Guid id);

        void Add(User newUser);

        User UserEntity(string email, string password, string phone, Role role);

        void Update(Guid id,User updatedUser);

        User UpdatedUserEntity(string email, string password, string phone, Role role);

        void DeleteUser(Guid userId);
    }
}