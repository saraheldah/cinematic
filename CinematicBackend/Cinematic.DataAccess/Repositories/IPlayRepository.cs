using System;
using System.Collections.Generic;
using Cinematic.DataAccess.Entities;

namespace Cinematic.DataAccess.Repositories
{
    public interface IPlayRepository
    {
        List<Play> GetAll();
        Play Get(Guid id);
        List<Play> GetPlayByTheaterId(Guid id);
        void Add(Play play,Guid id);
        void Delete(Guid playId);
        void Update(Guid id,Play seat);
    }
}