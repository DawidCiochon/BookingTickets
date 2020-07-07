using BookingTickets.Models;

namespace BookingTickets.Data
{
    public class MovieRepository : Repository<Movie, BookingTicketsContext>
    {
        public MovieRepository(BookingTicketsContext context) : base(context){
            
        }
    }
}