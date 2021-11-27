using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Cinematic.DataAccess.Entities
{
    [BsonIgnoreExtraElements]
    public class Theater
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        
        public List<Guid> PlayIds { get; set; }
    }
}