using System;

namespace Cinematic.DataAccess.Entities
{
    public class Play
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public DateTime Time { get; set; }
        
        public string Category { get; set; }
    }
}