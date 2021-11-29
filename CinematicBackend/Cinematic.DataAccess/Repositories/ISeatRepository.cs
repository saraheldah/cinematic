using System;
using System.Collections.Generic;
using Cinematic.DataAccess.Entities;

namespace Cinematic.DataAccess.Repositories
{
    public interface ISeatRepository
    {
        List<Seat> GetAll();
        Seat Get(Guid id);
        List<Seat> GetSeats(Guid playId, Guid userId);
        List<Seat> GetPendingSeats();
        void Add(List<Seat> seats);
        void Accept(Guid id);
        void Decline(Guid id);

        void Delete(Guid seatId);
    }
}