using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Cinematic.DataAccess.Entities
{
    [BsonIgnoreExtraElements]
    public class Play
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public int Duration { get; set; }
        public Guid TheaterId { get; set; }
        public List<Guid> SeatIds { get; set; }
    }
}