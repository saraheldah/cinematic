using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using AutoMapper;
using AutoMapper.Configuration;
using AutoMapper.Configuration.Conventions;
using AutoMapper.Internal;

using Cinematic.Business.DTO;
using Cinematic.DataAccess.Entities;

namespace Cinematic.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>(); // means you want to map from User to UserDTO
            CreateMap<UserDTO, User>(); 
            
            CreateMap<Seat, SeatDTO>(); 
            CreateMap<SeatDTO, Seat>(); 
            
            CreateMap<Play, PlayDTO>(); 
            CreateMap<PlayDTO, Play>(); 
            
            CreateMap<Theater, TheaterDTO>(); 
            CreateMap<TheaterDTO, Theater>(); 
        }
    }
}