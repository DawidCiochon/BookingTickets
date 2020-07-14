using System.Collections.Generic;

namespace BookingTickets.DTOs
{
    public class MovieDTO
    {
        public int Id {get; set;}
        public string Title {get; set;}
        public string Description {get; set;}
        public string Picture {get; set;}
        public int Duration {get; set;}
        public ICollection<SeanceDTO> Seances {get; set;}
    }
}