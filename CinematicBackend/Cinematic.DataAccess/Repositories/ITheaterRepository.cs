using System;
using System.Collections.Generic;
using Cinematic.DataAccess.Entities;

namespace Cinematic.DataAccess.Repositories
{
    public interface ITheaterRepository
    {
        List<Theater> GetAll();
        Theater Get(Guid id);
        void Add(Theater theater);
        void Delete(Guid id);
        void Update(Guid id, Theater theater);
    }
}