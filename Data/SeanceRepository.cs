using BookingTickets.Models;

namespace BookingTickets.Data
{
    public class SeanceRepository : Repository<Seance, BookingTicketsContext>
    {
        public SeanceRepository(BookingTicketsContext context) : base(context){
            
        }
    }
}