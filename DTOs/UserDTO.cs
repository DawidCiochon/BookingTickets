using System.Collections.Generic;

namespace BookingTickets.DTOs
{
    public class UserDTO
    {
        public int Id {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public bool isAdmin {get; set;}
        public ICollection<ReservationDTO> Reservations {get; set;}
    }
}