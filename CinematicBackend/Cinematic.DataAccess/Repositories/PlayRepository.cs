using System.Collections.Generic;
using System.Linq;
using Cinematic.DataAccess.Entities;

namespace Cinematic.DataAccess.Repositories
{
    public class PlayRepository : IPlayRepository
    {
        static List<Play> _plays;

        public PlayRepository()
        {
            if (_plays == null)
            {
                _plays = new List<Play>();
            }
        }
        public List<Play> GetAll()
        {
            return _plays;
        }
        
        public Play Get(int id)
        {
            return _plays.SingleOrDefault(x => x.Id == id);
        }
    
        public void Add(Play play)
        {
            _plays.Add(play);
        }

        public void Delete(Play play)
        {
            _plays.Remove(play);
        }

        public void Update(int id,Play play)
        {
            var updatedPlay = _plays.SingleOrDefault(x => x.Id == id);
            updatedPlay.Title = play.Title;
            updatedPlay.Time = play.Time;
            updatedPlay.Category = play.Category;
        }
    }
}