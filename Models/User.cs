using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using BookingTickets.Data;

namespace BookingTickets.Models
{
    public enum UserType{
        client = 0,
        admin = 1
    }
    public class User : IEntity
    {
        public int Id {get; set;}
        [Required]
        [MinLength(3, ErrorMessage="Name must be longer than 3 characters")]
        public string FirstName {get; set;}

        [Required]
        public string LastName {get; set;}

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email {get; set;}

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage="Password must be longer than 3 signs")]
        public string Password {get; set;}
        public UserType userType {get; set;}
        public ICollection<Reservation> Reservations {get; set;}
    }
}