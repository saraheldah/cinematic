using System;
using System.Collections.Generic;
using Cinematic.Business.DTO;
using Cinematic.DataAccess.Entities;

namespace Cinematic.Business.Managers
{
    public interface IPlayManager
    {
       List<PlayDTO> GetAll();

       PlayDTO Get(int id);

       void Add(Play newPlay);

       Play PlayEntity(string title, DateTime time, string category);

       void Update(int id, Play updatedplay);

       Play UpdatedplayEntity(string title, DateTime time, string category);

       void DeleteSeat(Play play);
    }
}