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
        private readonly ITheaterRepository _theaterRepository;
        private readonly ISeatRepository _seatRepository;
        private readonly IPlayRepository _playRepository;
        private readonly IMapper _mapper;
        
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
            if (theaterEntity == null) throw new Exception("theater not found");
            var theaterDto = _mapper.Map<TheaterDTO>(theaterEntity);
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