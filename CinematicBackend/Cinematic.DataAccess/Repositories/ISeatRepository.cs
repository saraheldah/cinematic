using System.Collections.Generic;
using Cinematic.DataAccess.Entities;

namespace Cinematic.DataAccess.Repositories
{
    public interface ISeatRepository
    {
        List<Seat> GetAll();
        Seat Get(int id);
        void Add(Seat seat);
        void Delete(Seat seat);
        void Update(int id,Seat seat);
    }
}