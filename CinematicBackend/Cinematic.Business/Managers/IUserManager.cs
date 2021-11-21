using Cinematic.Business.DTO;
using Cinematic.Common;
using Cinematic.DataAccess.Entities;

namespace Cinematic.Business.Managers
{
    public interface IUserManager
    {
        UserDTO Get(int id);

        void Add(User newUser);

        User UserEntity(string email, string password, string phone, Role role);

        void Update(int id,User updatedUser);

        User UpdatedUserEntity(string email, string password, string phone, Role role);

        void DeleteUser(User user);
    }
}