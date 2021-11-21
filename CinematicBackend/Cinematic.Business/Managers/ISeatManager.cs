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
        SeatDTO Get(int id);

        void Add(Seat newSeat);

        Seat SeatEntity(string row, string number, int theaterId,int playId,int userId);

        void Update(int id, Seat updatedSeat);

        Seat UpdatedSeatEntity(string row, string number, int theaterId,int playId,int userId);

        void DeleteSeat(Seat seat);
    }
}