using System;
using Cinematic.Common;
using MongoDB.Bson.Serialization.Attributes;


namespace Cinematic.DataAccess.Entities
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public Role Role { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}