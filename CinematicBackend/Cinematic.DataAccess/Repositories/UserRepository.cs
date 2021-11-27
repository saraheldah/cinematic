using System;
using System.Collections.Generic;
using System.Linq;
using Cinematic.DataAccess.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Cinematic.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _userCollection;

        public UserRepository(IMongoClient client)
        {
            var database = client.GetDatabase("cinematic");
            _userCollection = database.GetCollection<User>("user");
        }
        
        public List<User> GetAll()
        {
            return _userCollection.Find(new BsonDocument()).ToList();
        }

        public User Get(Guid id)
        {
            var filter = Builders<User>.Filter.Eq("Id", id);
            return _userCollection.Find(filter).First();
        }

        public void Add(User user)
        {
            user.Id = Guid.NewGuid();
            _userCollection.InsertOne(user);
        }

        public void Delete(Guid userId)
        {
            var filter = Builders<User>.Filter.Eq("Id", userId);
            _userCollection.DeleteOne(filter);
        }

        public void Update(Guid id, User newUser)
        {
            var result = _userCollection.ReplaceOne(new BsonDocument("_id", id), newUser,
                new UpdateOptions {IsUpsert = true});
        }
    }
}