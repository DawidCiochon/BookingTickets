using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using BookingTickets.Data;

namespace BookingTickets.Models
{
    public class Movie : IEntity
    {
        public int Id {get; set;}
        
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
        public ICollection<Seance> Seances {get; set;}
    }
}