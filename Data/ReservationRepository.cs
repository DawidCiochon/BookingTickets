using BookingTickets.Models;

namespace BookingTickets.Data
{
    public class ReservationRepository : Repository<Reservation, BookingTicketsContext>
    {
        public ReservationRepository(BookingTicketsContext context) : base(context){
            
        }
    }
}