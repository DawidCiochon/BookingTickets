using System.ComponentModel.DataAnnotations;

namespace BookingTickets.DTOs
{
    public class UserCreateDTO
    {
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
        [MinLength(8, ErrorMessage="Password must be longer than 8 characters")]
        public string Password {get; set;}
        //public bool isAdmin {get; set;}
    }
}