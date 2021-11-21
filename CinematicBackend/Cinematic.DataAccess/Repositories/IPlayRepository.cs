using System.Collections.Generic;
using Cinematic.DataAccess.Entities;

namespace Cinematic.DataAccess.Repositories
{
    public interface IPlayRepository
    {
        List<Play> GetAll();
        Play Get(int id);
        void Add(Play play);
        void Delete(Play play);
        void Update(int id,Play seat);
    }
}