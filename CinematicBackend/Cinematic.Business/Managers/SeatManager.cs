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
    public class SeatManager : ISeatManager
    {
        protected readonly ISeatRepository _seatRepository;
        protected readonly IUserRepository _userRepository;
        protected readonly IMapper _mapper;
        public SeatManager(ISeatRepository seatRepository, IUserRepository userRepository,IMapper mapper)
        {
            _seatRepository = seatRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        
        public List<SeatDTO> GetAll()
        {
            var seatEntityList = _seatRepository.GetAll().ToList();
            var userEntityList = _userRepository.GetAll().ToList();
            var seatDtoList = _mapper.Map<List<SeatDTO>>(seatEntityList);
            // foreach (var seatDto in seatDtoList)
            // {
            //     var userEntities = userEntityList.ToList();
            //     seatDto.ReservedBy = userEntities
            //         .Where(x => x.Id == seatDto.ReservedBy.Id)
            //         .Select(y =>
            //             new UserDTO()
            //             {
            //                 Id = y.Id,
            //                 Email = y.Email,
            //                 Phone = y.Phone,
            //                 Password = y.Password
            //             }).ToList();
            // }
            return seatDtoList;
        }
        
        public SeatDTO Get(Guid id)
        {
            var seatEntity = _seatRepository.Get(id);
            if (seatEntity == null) throw new Exception("seat not available");
            var seatDto = _mapper.Map<SeatDTO>(seatEntity);
            return seatDto;
        }
        
        public void Add(Seat newSeat)
        {
            _seatRepository.Add(newSeat);
        }
        
        public Seat SeatEntity(string row, string number, Guid theaterId,Guid playId,Guid userId)
        {
            Seat newSeat = new Seat
            {
                Row = row, 
                Number = number, 
                TheaterId = theaterId,
            };
            return newSeat;
        }
        
        public void Update(Guid id, Seat updatedSeat)
        {
            _seatRepository.Update(id,updatedSeat);
        }
        
        public Seat UpdatedSeatEntity(string row, string number, Guid theaterId,Guid playId,Guid userId)
        {
            Seat updatedSeat = new Seat
            {
                Row = row, 
                Number = number, 
                TheaterId = theaterId,
            };
            return updatedSeat;
        }
        
        public void Delete(Guid seatId)
        {
            _seatRepository.Delete(seatId);
        }
    }
}