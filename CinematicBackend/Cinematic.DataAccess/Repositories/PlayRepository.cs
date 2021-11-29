using System;
using System.Collections.Generic;
using System.Linq;
using Cinematic.DataAccess.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Cinematic.DataAccess.Repositories
{
    public class PlayRepository : IPlayRepository
    {
        private readonly IMongoCollection<Play> _playCollection;

        public PlayRepository(IMongoClient client)
        {
            var database = client.GetDatabase("cinematic");
            _playCollection = database.GetCollection<Play>("play");
        }
        public List<Play> GetAll()
        {
            return _playCollection.Find(new BsonDocument()).ToList();
        }
        
        public Play Get(Guid id)
        {
            var filter = Builders<Play>.Filter.Eq("Id",id);
            return _playCollection.Find(filter).FirstOrDefault();
        }
        
        public List<Play> GetPlayByTheaterId(Guid id)
        {
            var filter = Builders<Play>.Filter.Eq("TheaterId", id);
            return _playCollection.Find(filter).ToList();
        }
    
        public void Add(Play play,Guid id)
        {
            play.Id = Guid.NewGuid();
            play.TheaterId = id;
            _playCollection.InsertOne(play);
        }

        public void Delete(Guid playId)
        {
            var filter = Builders<Play>.Filter.Eq("Id", playId);
            _playCollection.DeleteOne(filter);
        }

        public void Update(Guid id,Play play)
        {
            var filter = Builders<Play>.Filter.Eq("Id",id);
            var update = Builders<Play>.Update.Set(s => s.Title, play.Title).Set(s=>s.Category, play.Category).Set(s=>s.Duration,play.Duration);
            _playCollection.UpdateOne(filter, update);
        }
    }
}