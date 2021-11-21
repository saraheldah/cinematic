using System;

namespace Cinematic.Business.DTO
{
    public class PlayDTO
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public DateTime Time { get; set; }
        
        public string Category { get; set; }
    }
}