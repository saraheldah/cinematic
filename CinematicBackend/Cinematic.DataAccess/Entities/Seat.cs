using System;
// using Cinematic.Common;

namespace Cinematic.DataAccess.Entities
{
    public class Seat
    {
        public int Id { get; set; }
        
        public string Row { get; set; }
        
        public string Number { get; set; }
        
        public int TheaterId { get; set; }
        
        public int PlayId { get; set; }
        
        public bool IsReserved { get; set; }
        
        public int UserId { get; set; }
    }
}