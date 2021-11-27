using System;
using System.Collections.Generic;
using Cinematic.Business.DTO;
using Cinematic.DataAccess.Entities;

namespace Cinematic.Business.Managers
{
    public interface IPlayManager
    {
       List<PlayDTO> GetAll();

       PlayDTO Get(Guid id);

       List<PlayDTO> GetPlayByTheaterId(Guid id);

       void Add(PlayDTO newPlay,Guid id);

       Play PlayEntity(string title, DateTime time, string category);

       void Update(Guid id, Play updatedplay);

       Play UpdatedplayEntity(string title, string category, int duration);

       void Delete(Guid playId);
    }
}