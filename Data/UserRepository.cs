using BookingTickets.Models;

namespace BookingTickets.Data
{
    public class UserRepository : Repository<User, BookingTicketsContext>
    {
        public UserRepository(BookingTicketsContext context) : base(context){
            
        }        
    }
}