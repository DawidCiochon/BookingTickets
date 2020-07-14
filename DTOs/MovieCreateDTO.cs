using System.ComponentModel.DataAnnotations;

namespace BookingTickets.DTOs
{
    public class MovieCreateDTO
    {
        [Required]
        [MinLength(3, ErrorMessage="Too short title")]
        public string Title {get; set;}
        [Required]
        [MaxLength(100, ErrorMessage="Too long description")]
        public string Description {get; set;}
        [Required]
        [DataType(DataType.ImageUrl)]
        public string Picture {get; set;}
        [Required]
        public int Duration {get; set;}
    }
}