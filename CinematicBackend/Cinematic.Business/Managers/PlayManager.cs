using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Cinematic.Business.DTO;
using Cinematic.DataAccess.Entities;
using Cinematic.DataAccess.Repositories;

namespace Cinematic.Business.Managers
{
    public class PlayManager : IPlayManager
    {
        protected readonly IPlayRepository _playRepository;
        protected readonly IMapper _mapper;
        public PlayManager(IPlayRepository playRepository, IMapper mapper)
        {
            _playRepository = playRepository;
            _mapper = mapper;
        }
        
        public List<PlayDTO> GetAll()
        {
            var playEntityList = _playRepository.GetAll().ToList();
            var playDtoList = _mapper.Map<List<PlayDTO>>(playEntityList);
            return playDtoList;
        }
        
        public PlayDTO Get(int id)
        {
            var playEntity = _playRepository.Get(id);
            if (playEntity == null) throw new Exception("play not available");
            var playDto = _mapper.Map<PlayDTO>(playEntity);
            return playDto;
        }
        
        public void Add(Play newPlay)
        {
            _playRepository.Add(newPlay);
        }
        
        public Play PlayEntity(string title,DateTime time,string category)
        {
            Play newPlay = new Play
            {
                Title = title,
                Time = time,
                Category = category
            };
            return newPlay;
        }
        
        public void Update(int id, Play updatedplay)
        {
            _playRepository.Update(id,updatedplay);
        }
        
        public Play UpdatedplayEntity(string title,DateTime time,string category)
        {
            Play updatedPlay = new Play
            {
                Title = title,
                Time = time,
                Category = category
            };
            return updatedPlay;
        }
        
        public void DeleteSeat(Play play)
        {
            _playRepository.Delete(play);
        }
    }
}