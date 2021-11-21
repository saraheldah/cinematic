using System.Collections.Generic;
using System.Linq;
using Cinematic.DataAccess.Entities;

namespace Cinematic.DataAccess.Repositories
{
    public class SeatRepository : ISeatRepository
    {
        static List<Seat> _seats;

        public SeatRepository()
        {
            if (_seats == null)
            {
                _seats = new List<Seat>();
            }
        }
        
        public List<Seat> GetAll()
        {
            return _seats;
        }
        
        public Seat Get(int id)
        {
            return _seats.SingleOrDefault(x => x.Id == id);
        }
    
        public void Add(Seat seat)
        {
            _seats.Add(seat);
        }
        
        public void Delete(Seat seat)
        {
            _seats.Remove(seat);
        }

        public void Update(int id,Seat seat)
        {
            var updatedSeat = _seats.SingleOrDefault(x => x.Id == id);
            updatedSeat.Number = seat.Number;
            updatedSeat.Row = seat.Row;
            updatedSeat.IsReserved = seat.IsReserved;
            updatedSeat.UserId = seat.UserId;
        }
    }
}