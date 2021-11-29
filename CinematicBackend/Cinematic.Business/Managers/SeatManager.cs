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
        private readonly ISeatRepository _seatRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPlayRepository _playRepository;
        private readonly IMapper _mapper;

        public SeatManager(ISeatRepository seatRepository, IUserRepository userRepository,
            IPlayRepository playRepository, IMapper mapper)
        {
            _seatRepository = seatRepository;
            _userRepository = userRepository;
            _playRepository = playRepository;
            _mapper = mapper;
        }

        public List<SeatDTO> GetAll()
        {
            var seatEntityList = _seatRepository.GetAll().ToList();
            var seatDtoList = _mapper.Map<List<SeatDTO>>(seatEntityList);
            return seatDtoList;
        }

        public SeatDTO Get(Guid id)
        {
            var seatEntity = _seatRepository.Get(id);
            if (seatEntity == null) throw new Exception("seat not available");
            var seatDto = _mapper.Map<SeatDTO>(seatEntity);
            return seatDto;
        }

        public void Add(List<SeatDTO> seatDtos)
        {
            var seats = _mapper.Map<List<Seat>>(seatDtos);
            _seatRepository.Add(seats);
        }

        public List<SeatDTO> GetPendingSeats()
        {
            var seatsEntity = _seatRepository.GetPendingSeats();

            if (seatsEntity == null)
                throw new Exception("seat not available");
            var seatDtoList = _mapper.Map<List<SeatDTO>>(seatsEntity);
            foreach (var seat in seatDtoList)
            {
                var playEntity = _playRepository.Get(seat.PlayId);
                seat.Play = _mapper.Map<PlayDTO>(playEntity);
                var userEntity = _userRepository.Get(seat.UserId);
                seat.User = _mapper.Map<UserDTO>(userEntity);
            }
            return seatDtoList;
        }
        
        public List<SeatDTO> GetSeats(Guid playId,Guid userId)
        {
            var seatsEntity = _seatRepository.GetSeats(playId,userId);
            if (seatsEntity == null)
                throw new Exception("seat not available");
            var seatDtoList = _mapper.Map<List<SeatDTO>>(seatsEntity);
            // foreach (var seat in seatDtoList)
            // {
            //     var playEntity = _playRepository.Get(seat.PlayId);
            //     seat.Play = _mapper.Map<PlayDTO>(playEntity);
            //     var userEntity = _userRepository.Get(seat.UserId);
            //     seat.User = _mapper.Map<UserDTO>(userEntity);
            // }
            return seatDtoList;
        }

        public Seat SeatEntity(string row, string number, Guid theaterId, Guid playId, Guid userId)
        {
            var newSeat = new Seat
            {
                Row = row,
                Number = number,
                TheaterId = theaterId,
            };
            return newSeat;
        }

        public void Accept(Guid id)
        {
            _seatRepository.Accept(id);
        }
        
        public void Decline(Guid id)
        {
            _seatRepository.Decline(id);
        }

        public Seat UpdatedSeatEntity(string row, string number, Guid theaterId, Guid playId, Guid userId)
        {
            var updatedSeat = new Seat
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