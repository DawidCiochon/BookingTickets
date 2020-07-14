namespace BookingTickets.DTOs
{
    public class SeatDTO
    {
        public int Id {get; set;}
        public int Number {get; set;}
        public bool Occupied {get; set;} 
        public int ReservationId {get; set;}
    }
}