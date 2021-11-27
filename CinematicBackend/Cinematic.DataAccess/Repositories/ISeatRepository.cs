using System;
using System.Collections.Generic;
using Cinematic.DataAccess.Entities;

namespace Cinematic.DataAccess.Repositories
{
    public interface ISeatRepository
    {
        List<Seat> GetAll();
        Seat Get(Guid id);
        // List<Seat> Find(Guid playId);
        void Add(Seat seat);
        void Delete(Guid seatId);
        void Update(Guid id,Seat seat);
    }
}