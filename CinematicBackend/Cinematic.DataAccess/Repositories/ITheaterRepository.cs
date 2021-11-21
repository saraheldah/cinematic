using System.Collections.Generic;
using Cinematic.DataAccess.Entities;

namespace Cinematic.DataAccess.Repositories
{
    public interface ITheaterRepository
    {
        List<Theater> GetAll();
        Theater Get(int id);
        void Add(Theater theater);
        void Delete(Theater theater);
        void Update(int id, Theater theater);
    }
}