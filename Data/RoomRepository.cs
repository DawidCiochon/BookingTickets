using BookingTickets.Models;

namespace BookingTickets.Data
{
    public class RoomRepository : Repository<Room, BookingTicketsContext>
    {
        public RoomRepository(BookingTicketsContext context) : base(context){
            
        }
    }
}