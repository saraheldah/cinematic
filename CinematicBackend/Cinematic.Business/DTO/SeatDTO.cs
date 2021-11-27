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
        
        public UserDTO ReservedBy { get; set; }
        
        public Guid PlayId { get; set; }
    }
}