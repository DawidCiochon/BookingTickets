using System.Runtime.CompilerServices;
using System.Xml.XPath;
using System;
using System.ComponentModel.DataAnnotations;
using BookingTickets.Data;

namespace BookingTickets.Models
{
    public class Seat :IEntity
    {
        //[Key]
        public int Id {get; set;}

        [Required]
        [Range(1, 30, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Number {get; set;}

        [Required]
        public bool Occupied {get; set;} 
        public int ReservationId {get; set;}
    }
}