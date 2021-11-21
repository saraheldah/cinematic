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
        protected readonly IUserRepository _userRepository;
        protected readonly IMapper _mapper;
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
        
        public UserDTO Get(int id)
        {
            var userEntity = _userRepository.Get(id);
            if (userEntity == null) throw new Exception("user not found");
            var userDto = _mapper.Map<UserDTO>(userEntity);
            return userDto;
        }
        
        public void Add(User newUser)
        {
            _userRepository.Add(newUser);
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
        
        public void Update(int id, User updatedUser)
        {
            _userRepository.Update(id,updatedUser);
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
        
        public void DeleteUser(User user)
        {
            _userRepository.Delete(user);
        }
    }
}