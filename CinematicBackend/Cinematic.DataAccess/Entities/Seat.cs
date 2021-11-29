using System;
using Cinematic.Common;
using MongoDB.Bson.Serialization.Attributes;

namespace Cinematic.DataAccess.Entities
{
    [BsonIgnoreExtraElements]
    public class Seat
    {
        [BsonId]
        public Guid Id { get; set; }
        
        public string Row { get; set; }
        
        public string Number { get; set; }

        public Guid TheaterId { get; set; }
        
        public ReservationStatus Status { get; set; }
        
        public Guid UserId { get; set; }
        
        public Guid PlayId { get; set; }
    }
}