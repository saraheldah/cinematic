namespace Cinematic.Business.DTO
{
    public class SeatDTO
    {
        public int Id { get; set; }
        
        public string Row { get; set; }
        
        public string Number { get; set; }
        
        public bool IsReserved { get; set; }
        
        public UserDTO ReservedBy { get; set; }
    }
}