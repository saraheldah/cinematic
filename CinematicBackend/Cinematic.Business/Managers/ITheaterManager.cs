using System;
using System.Collections.Generic;
using Cinematic.Business.DTO;
using Cinematic.DataAccess.Entities;

namespace Cinematic.Business.Managers
{
    public interface ITheaterManager
    {
        List<TheaterDTO> GetAll();

        TheaterDTO Get(int id);

        void Add(Theater newTheater);

        Theater TheaterEntity(string name, string location, int seatsNumber);

        void Update(int id, Theater updatedTheater);

        Theater UpdatedTheaterEntity(string name, string location, int seatsNumber);

        void DeleteTheater(Theater theater);
    }
}