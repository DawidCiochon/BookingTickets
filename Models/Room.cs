using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using BookingTickets.Data;

namespace BookingTickets.Models
{
    public class Room : IEntity
    {
        public int Id {get; set;}

        [Required]
        [MinLength(5, ErrorMessage="To short name. Minimum is 5 characters")]
        public string RoomName {get; set;}
        public ICollection<Seance> Seances {get; set;}
    }
}