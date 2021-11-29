using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Cinematic.Business.DTO;
using Cinematic.Common;
using Cinematic.DataAccess.Entities;
using Cinematic.DataAccess.Repositories;

namespace Cinematic.Business.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserManager(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public List<UserDTO> GetAll()
        {
            var userEntityList = _userRepository.GetAll().ToList();
            var userDtoList = _mapper.Map<List<UserDTO>>(userEntityList);
            return userDtoList;
        }
        
        public UserDTO Get(Guid id)
        {
            var userEntity = _userRepository.Get(id);
            if (userEntity == null) throw new Exception("user not found");
            var userDto = _mapper.Map<UserDTO>(userEntity);
            return userDto;
        }
        
        
        public User UserEntity(string email, string password, string phone,Role role)
        {
            User newUser = new User
            {
                Email = email,
                Password = password,
                Phone = phone,
                Role = role
            };
            return newUser;
        }
        
        public User UpdatedUserEntity(string email, string password, string phone,Role role)
        {
            User updatedUser = new User
            {
                Email = email,
                Password = password,
                Phone = phone,
                Role = role
            };
            return updatedUser;
        }
        
        public void DeleteUser(Guid userId)
        {
            _userRepository.Delete(userId);
        }
    }
}