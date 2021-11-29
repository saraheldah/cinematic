using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Cinematic.Common;
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
        public void Delete(Guid userId)
        {
            var filter = Builders<User>.Filter.Eq("Id", userId);
            _userCollection.DeleteOne(filter);
        }
        public bool UserExists(string username)
        {
            var filter = Builders<User>.Filter.Eq("Username", username);
            if ( _userCollection.Find(filter).Any())
                return true;
            return false;
        }
        public User Login(string username, string password)
        {
            var user = _userCollection.Find(Builders<User>.Filter.Eq("Username", username)).FirstOrDefault();
            if (user == null)
                return null;
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;
            return user;
        }
        public User Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Id = Guid.NewGuid();
            user.Role = Role.User;
            _userCollection.InsertOne(user);
            return user;
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}