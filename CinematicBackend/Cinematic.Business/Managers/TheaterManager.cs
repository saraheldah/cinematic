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
    public class TheaterManager : ITheaterManager
    {
        protected readonly ITheaterRepository _theaterRepository;
        protected readonly ISeatRepository _seatRepository;
        protected readonly IPlayRepository _playRepository;
        protected readonly IMapper _mapper;
        
        public TheaterManager(
            ITheaterRepository theaterRepository,
            ISeatRepository seatRepository,
            IPlayRepository playRepository, 
            IMapper mapper)
        {
            _theaterRepository = theaterRepository;
            _seatRepository = seatRepository;
            _playRepository = playRepository;
            _mapper = mapper;
        }
        
        public List<TheaterDTO> GetAll()
        {
            var theaterEntityList = _theaterRepository.GetAll().ToList();
            var playEntityList = _playRepository.GetAll().ToList();
            var theaterDtoList = _mapper.Map<List<TheaterDTO>>(theaterEntityList);
            // foreach (var play in playEntityList)
            // {
            //     var theaterEntities = theaterEntityList.ToList();
            // }
            // foreach (var theaterDto in theaterDtoList)
            // {
            //     var playsEntities = playEntityList.ToList();
            //     theaterDto.Plays = playsEntities
            //         .Where( x => x.TheaterIds.Contains(theaterDto.Id))
            //         .Select(y =>
            //             new PlayDTO()
            //             {
            //                 Id = y.Id,
            //                 Title = y.Title,
            //                 Category = y.Category,
            //                 Duration = y.Duration
            //             }).ToList();
            // }
            return theaterDtoList;
        }
        
        public TheaterDTO Get(Guid id)
        {
            var theaterEntity = _theaterRepository.Get(id);
            var playEntityList = _playRepository.GetAll().ToList();
            if (theaterEntity == null) throw new Exception("theater not found");
            var theaterDto = _mapper.Map<TheaterDTO>(theaterEntity);
            // theaterDto.Plays = new List<PlayDTO>();
            // foreach (var play in plays)
            // {
            //     var playDto = new PlayDTO()
            //     {
            //         Id =  play.Id,
            //         Title = play.Title,
            //         Category = play.Category,
            //         Duration = play.Duration
            //     };
            //     // get the seat reservation by seat Id and play id
            //     // if it's null then ignore the reserved by and add the status as free
            //     // else fill the reservation status and reserved by (here you need to get the user)
            //     theaterDto.Plays.Add(playDto)
            // }
            return theaterDto;
        }
        
        public void Add(TheaterDTO newTheater)
        {
            var theater = _mapper.Map<Theater>(newTheater);
            _theaterRepository.Add(theater);
        }
        
        public Theater TheaterEntity(string name, string location)
        {
            Theater newTheater = new Theater
            {
                Id = Guid.NewGuid(),
                Name = name,
                Location = location,
            };
            return newTheater;
        }
        
        public void Update(Guid id, TheaterDTO updatedTheater)
        {
            var theater = _mapper.Map<Theater>(updatedTheater);
            _theaterRepository.Update(id,theater);
        }
        
        public Theater UpdatedTheaterEntity(string name, string location)
        {
            Theater updatedTheater = new Theater
            {
                Name = name,
                Location = location,
            };
            return updatedTheater;
        }
        
        public void DeleteTheater(Guid theaterId)
        {
            _theaterRepository.Delete(theaterId);
        }
    }
}