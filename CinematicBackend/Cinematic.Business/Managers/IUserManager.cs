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
        User UserEntity(string email, string password, string phone, Role role);
        void DeleteUser(Guid userId);
    }
}