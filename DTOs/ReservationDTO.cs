namespace BookingTickets.DTOs
{
    public class ReservationDTO
    {
        public int Id {get; set;}
        public int UserId {get; set;}
        public int SeanceId {get; set;}
        public int SeatId {get; set;}
    }
}