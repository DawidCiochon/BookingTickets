using System.Collections.Generic;

namespace BookingTickets.Models
{
    public class Room
    {
        public int Id {get; set;}
        public string RoomName {get; set;}
        public ICollection<Seat> Seats {get; set;}
    }
}