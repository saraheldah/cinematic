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
        protected readonly IMapper _mapper;
        public SeatManager(ISeatRepository seatRepository, IMapper mapper)
        {
            _seatRepository = seatRepository;
            _mapper = mapper;
        }
        
        public List<SeatDTO> GetAll()
        {
            var seatEntityList = _seatRepository.GetAll().ToList();
            var seatDtoList = _mapper.Map<List<SeatDTO>>(seatEntityList);
            return seatDtoList;
        }
        
        public SeatDTO Get(int id)
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
        
        public Seat SeatEntity(string row, string number, int theaterId,int playId,int userId)
        {
            Seat newSeat = new Seat
            {
                Row = row, 
                Number = number, 
                TheaterId = theaterId,
                PlayId = playId,
                UserId = userId
            };
            return newSeat;
        }
        
        public void Update(int id, Seat updatedSeat)
        {
            _seatRepository.Update(id,updatedSeat);
        }
        
        public Seat UpdatedSeatEntity(string row, string number, int theaterId,int playId,int userId)
        {
            Seat updatedSeat = new Seat
            {
                Row = row, 
                Number = number, 
                TheaterId = theaterId,
                PlayId = playId,
                UserId = userId
            };
            return updatedSeat;
        }
        
        public void DeleteSeat(Seat seat)
        {
            _seatRepository.Delete(seat);
        }
    }
}