using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Cinematic.DataAccess.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Cinematic.DataAccess.Repositories
{
    public class SeatRepository : ISeatRepository
    {
        private readonly IMongoCollection<Seat> _seatCollection;
        
        public SeatRepository(IMongoClient client)
        {
            var database = client.GetDatabase("cinematic");
            _seatCollection = database.GetCollection<Seat>("seat");
        }
        
        public List<Seat> GetAll()
        {
            return _seatCollection.Find(new BsonDocument()).ToList();
        }
        
        public Seat Get(Guid id)
        {
            var filter = Builders<Seat>.Filter.Eq("Id", id);
            return _seatCollection.Find(filter).First();
        }

        // public List<Seat> Find(Guid playId)
        // {
        //    return _seats.Where(x => x.PlayId == playId).ToList();
        // }
    
        public void Add(Seat seat)
        {
            seat.Id = Guid.NewGuid();
            _seatCollection.InsertOne(seat);
        }
        
        public void Delete(Guid seatId)
        {
            var filter = Builders<Seat>.Filter.Eq("Id", seatId);
            _seatCollection.DeleteOne(filter);
        }

        public void Update(Guid id,Seat seat)
        {
            var filter = Builders<Seat>.Filter.Eq("Id",id);
            var update = Builders<Seat>.Update.Set(s => s.Status , seat.Status);
            _seatCollection.UpdateOne(filter, update);
        }
    }
}