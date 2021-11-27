using System;
using System.Collections.Generic;

namespace Cinematic.Business.DTO
{
    public class PlayDTO
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public string Category { get; set; }
        
        public int Duration { get; set; }
        
        public Guid TheaterId { get; set; }
    }
}