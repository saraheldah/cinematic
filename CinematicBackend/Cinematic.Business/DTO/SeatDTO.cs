using System;
using Cinematic.Common;

namespace Cinematic.Business.DTO
{
    public class SeatDTO
    {
        public Guid Id { get; set; }
        
        public string Row { get; set; }
        
        public string Number { get; set; }
        
        public ReservationStatus Status { get; set; }
        
        public PlayDTO Play { get; set; }
        
        public UserDTO User { get; set; }
        
        public Guid UserId { get; set; }
        
        public Guid PlayId { get; set; }
    }
}