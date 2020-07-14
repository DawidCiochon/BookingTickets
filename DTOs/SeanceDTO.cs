using System;
using System.Collections.Generic;

namespace BookingTickets.DTOs
{
    public class SeanceDTO
    {
        public int Id {get; set;}
        public DateTime StartDate {get; set;}
        public int MovieId {get; set;}
        public ICollection<ReservationDTO> Reservations {get; set;}
        public int RoomId {get; set;}
    }
}