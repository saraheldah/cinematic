using System.Collections.Generic;
using System.Linq;
using Cinematic.DataAccess.Entities;

namespace Cinematic.DataAccess.Repositories
{
    public class TheaterRepository : ITheaterRepository
    {
        static List<Theater> _theaters;

        public TheaterRepository()
        {
            if (_theaters == null)
            {
                _theaters = new List<Theater>();
            }
        }

        public List<Theater> GetAll()
        {
            return _theaters;
        }
        public Theater Get(int id)
        {
            return _theaters.SingleOrDefault(x => x.Id == id);
        }
    
        public void Add(Theater theater)
        {
            _theaters.Add(theater);
        }

        public void Delete(Theater theater)
        {
            _theaters.Remove(theater);
        }

        public void Update(int id, Theater theater)
        {
            var updatedTheater = _theaters.SingleOrDefault(x => x.Id == id);
            updatedTheater.Name = theater.Name;
            updatedTheater.Location = theater.Location;
            updatedTheater.SeatsNumber = theater.SeatsNumber;
        }
    }
}