using System;
using System.Collections.Generic;
// using Cinematic.Common;
// using Cinematic.DataAccess.Entities;
using Cinematic.Business.DTO;
using Cinematic.DataAccess.Entities;

namespace Cinematic.Business.Managers
{
    public interface ISeatManager
    {
        List<SeatDTO> GetAll();
        SeatDTO Get(Guid id);

        void Add(Seat newSeat);

        Seat SeatEntity(string row, string number, Guid theaterId,Guid playId,Guid userId);

        void Update(Guid id, Seat updatedSeat);

        Seat UpdatedSeatEntity(string row, string number, Guid theaterId,Guid playId,Guid userId);

        void Delete(Guid seatId);
    }
}