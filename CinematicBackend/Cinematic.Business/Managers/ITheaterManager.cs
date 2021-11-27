using System;
using System.Collections.Generic;
using Cinematic.Business.DTO;
using Cinematic.DataAccess.Entities;

namespace Cinematic.Business.Managers
{
    public interface ITheaterManager
    {
        List<TheaterDTO> GetAll();

        TheaterDTO Get(Guid id);

        void Add(TheaterDTO newTheater);

        Theater TheaterEntity(string name, string location);

        void Update(Guid id, TheaterDTO updatedTheater);

        Theater UpdatedTheaterEntity(string name, string location);

        void DeleteTheater(Guid theaterId);
    }
}