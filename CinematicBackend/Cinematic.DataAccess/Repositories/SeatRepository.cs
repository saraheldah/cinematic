using System;
using System.Collections.Generic;
using Cinematic.Common;
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
        
        public List<Seat> GetPendingSeats()
        {
            var filter = Builders<Seat>.Filter.Eq("Status", "2" );
            return _seatCollection.Find(filter).ToList();
        }
        
        public List<Seat> GetSeats(Guid playId,Guid userId)
        {
            var playFilter = Builders<Seat>.Filter.Eq("PlayId", playId);
            var userFilter = Builders<Seat>.Filter.Eq("UserId", userId);
            return _seatCollection.Find(playFilter & userFilter).ToList();
        }
        
        public void Add(List<Seat> seats)
        {
            foreach (var seat in seats)
            {
                seat.Id = Guid.NewGuid();
            }
            _seatCollection.InsertMany(seats);
        }
        
        public void Delete(Guid seatId)
        {
            var filter = Builders<Seat>.Filter.Eq("Id", seatId);
            _seatCollection.DeleteOne(filter);
        }

        public void Accept(Guid id)
        {
            var filter = Builders<Seat>.Filter.Eq("Id",id);
            var update = Builders<Seat>.Update.Set("Status", ReservationStatus.Confirmed);
            _seatCollection.UpdateOne(filter, update);
        }
        
        public void Decline(Guid id)
        {
            var filter = Builders<Seat>.Filter.Eq("Id",id);
            var update = Builders<Seat>.Update.Set("Status", ReservationStatus.Declined);
            _seatCollection.UpdateOne(filter, update);
        }
    }
}