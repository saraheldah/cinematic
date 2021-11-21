using System;
using Cinematic.Common;


namespace Cinematic.DataAccess.Entities
{
    public class User
    {
        public int Id { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }
        
        public string Phone { get; set; }
        public Role Role { get; set; }
    }
}