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
        protected readonly IMapper _mapper;
        public TheaterManager(ITheaterRepository theaterRepository, IMapper mapper)
        {
            _theaterRepository = theaterRepository;
            _mapper = mapper;
        }
        
        public List<TheaterDTO> GetAll()
        {
            var theaterEntityList = _theaterRepository.GetAll().ToList();
            var theaterDtoList = _mapper.Map<List<TheaterDTO>>(theaterEntityList);
            return theaterDtoList;
        }
        
        public TheaterDTO Get(int id)
        {
            var theaterEntity = _theaterRepository.Get(id);
            if (theaterEntity == null) throw new Exception("theater not found");
            var theaterDto = _mapper.Map<TheaterDTO>(theaterEntity);
            return theaterDto;
        }
        
        public void Add(Theater newTheater)
        {
            _theaterRepository.Add(newTheater);
        }
        
        public Theater TheaterEntity(string name, string location, int seatsNumber)
        {
            Theater newTheater = new Theater
            {
                Name = name,
                Location = location,
                SeatsNumber = seatsNumber
            };
            return newTheater;
        }
        
        public void Update(int id, Theater updatedTheater)
        {
            _theaterRepository.Update(id,updatedTheater);
        }
        
        public Theater UpdatedTheaterEntity(string name, string location, int seatsNumber)
        {
            Theater updatedTheater = new Theater
            {
                Name = name,
                Location = location,
                SeatsNumber = seatsNumber
            };
            return updatedTheater;
        }
        
        public void DeleteTheater(Theater theater)
        {
            _theaterRepository.Delete(theater);
        }
    }
}