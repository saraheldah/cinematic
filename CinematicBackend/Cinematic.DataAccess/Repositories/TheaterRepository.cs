using System;
using System.Collections.Generic;
using System.Linq;
using Cinematic.DataAccess.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;


namespace Cinematic.DataAccess.Repositories
{
    public class TheaterRepository : ITheaterRepository
    {
        private readonly IMongoCollection<Theater> _theaterCollection;


        public TheaterRepository(IMongoClient client)
        {
            var database = client.GetDatabase("cinematic");
            _theaterCollection = database.GetCollection<Theater>("theater");
        }

        public List<Theater> GetAll()
        {
            return _theaterCollection.Find(new BsonDocument()).ToList();
        }
        public Theater Get(Guid id)
        {
            var filter = Builders<Theater>.Filter.Eq("Id", id);
            return _theaterCollection.Find(filter).First();
        }
    
        public void Add(Theater theater)
        {
            theater.Id = Guid.NewGuid();
            _theaterCollection.InsertOne(theater);
        }

        public void Delete(Guid id)
        {
            var filter = Builders<Theater>.Filter.Eq("Id", id);
            _theaterCollection.DeleteOne(filter);
        }

        public void Update(Guid id, Theater theater)
        {
            var filter = Builders<Theater>.Filter.Eq("Id",id);
            var update = Builders<Theater>.Update.Set(s => s.Name, theater.Name).Set(s=>s.Location, theater.Location);
            _theaterCollection.UpdateOne(filter, update);
        }
    }
}