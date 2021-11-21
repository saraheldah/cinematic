using System;
using System.Collections.Generic;

namespace Cinematic.Business.DTO
{
    public class TheaterDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Location { get; set; }
        
        public List<SeatDTO> Seats { get; set; }
        
        public  List<PlayDTO> Plays { get; set; }//we might have multiple play for each theater and we have to retrive this list of plays
    }
}