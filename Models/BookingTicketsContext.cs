using Microsoft.EntityFrameworkCore;

namespace BookingTickets.Models
{
    public class BookingTicketsContext : DbContext
    {
        public BookingTicketsContext(DbContextOptions<BookingTicketsContext> options): base(options)
        {

        }

        public DbSet<User> Users {get; set;}
        public DbSet<Movie> Movies {get; set;}
        public DbSet<Reservation> Reservations {get; set;}
        public DbSet<Seat> Seats {get; set;}
        public DbSet<Room> Rooms {get; set;}
        public DbSet<Seance> Seances {get; set;}

        public override int SaveChanges(){
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}