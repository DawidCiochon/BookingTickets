using BookingTickets.Models;

namespace BookingTickets.Data
{
    public class SeatRepository : Repository<Seat, BookingTicketsContext>
    {
        public SeatRepository(BookingTicketsContext context) : base(context){
            
        }
    }
}