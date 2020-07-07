using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using BookingTickets.Data;

namespace BookingTickets.Models
{
    public class Seance : IEntity
    {
        public int Id {get; set;}

        [Required]
        [DataType(DataType.Time)]
        [Range(typeof(TimeSpan), "08:00", "23:00")]
        public DateTime StartDate {get; set;}
        public int MovieId {get; set;}
        public ICollection<Reservation> Reservations {get; set;}
        public int RoomId {get; set;}
    }
}