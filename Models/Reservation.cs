using BookingTickets.Data;

namespace BookingTickets.Models
{
    public class Reservation
    {
        public int Id {get; set;}
        public int UserId {get; set;}
        public int SeanceId {get; set;}
        public int SeatId {get; set;}
    }
}