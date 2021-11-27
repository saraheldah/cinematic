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
        protected readonly ITheaterRepository _theaterRepository;
        protected readonly ISeatRepository _seatRepository;
        protected readonly IMapper _mapper;
        public PlayManager(IPlayRepository playRepository,ITheaterRepository theaterRepository,ISeatRepository seatRepository, IMapper mapper)
        {
            _playRepository = playRepository;
            _theaterRepository = theaterRepository;
            _seatRepository = seatRepository;
            _mapper = mapper;
        }
        
        public List<PlayDTO> GetAll()
        {
            var playEntityList = _playRepository.GetAll().ToList();
            var playDtoList = _mapper.Map<List<PlayDTO>>(playEntityList);
            return playDtoList;
        }
        
        public PlayDTO Get(Guid id)
        {
            var playEntity = _playRepository.Get(id);
            var theaterEntityList = _theaterRepository.GetAll().ToList();
            var seatEntityList = _seatRepository.GetAll().ToList();
            if (playEntity == null) throw new Exception("play is not available");
            var playDto = _mapper.Map<PlayDTO>(playEntity);
            // foreach (var theater in theaterEntityList)
            // {
            //     var theaterEntities = theaterEntityList.ToList().Where(x=>x.Id );
            //     
            // }
            return playDto;
        }
        
        public List<PlayDTO> GetPlayByTheaterId(Guid id)
        {
            var playsEntity =_playRepository.GetPlayByTheaterId(id);
            if (playsEntity == null) throw new Exception("play is not available");
            var playDto = _mapper.Map<List<PlayDTO>>(playsEntity);
            return playDto;
        }
        public void Add(PlayDTO newPlay,Guid id)
        {
            var play = _mapper.Map<Play>(newPlay);
            _playRepository.Add(play,id);
        }
        
        public Play PlayEntity(string title,DateTime time,string category)
        {
            Play newPlay = new Play
            {
                Title = title,
                Category = category
            };
            return newPlay;
        }
        
        public void Update(Guid id, Play updatedplay)
        {
            _playRepository.Update(id,updatedplay);
        }
        
        public Play UpdatedplayEntity(string title,string category,int duration)
        {
            Play updatedPlay = new Play
            {
                Title = title,
                Category = category,
                Duration = duration
            };
            return updatedPlay;
        }
        
        public void Delete(Guid playId)
        {
            _playRepository.Delete(playId);
        }
    }
}