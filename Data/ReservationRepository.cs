using BookingTickets.Models;

namespace BookingTickets.Data
{
    public class ReservationRepository
    {
        private readonly BookingTicketsContext _context;
        public ReservationRepository(BookingTicketsContext context){
            this._context = context;
        }   

        public IEnumerable<Reservation> GetReservations()
        {
            return this._context.Reservations.ToList();
        }

        public Reservation GetReservationById(int reservationId){
            return this._context.Reservations.FirstOrDefault(r => r.Id == reservarionId);
        }

        public void InsertReservation(Reservation reservation){
            if(reservation == null){
                throw new ArgumentNullException(nameof(reservation));
            }
            this._context.Reservations.Add(reservation);
        }

        public void DeleteReservation(Reservation reservation){
            if(reservation == null){
                throw new ArgumentNullException(nameof(reservation));
            }
            this._context.Reservations.Remove(reservation);
        }

        public void UpdateReservation(Reservation reservation){
            //this._context.Entry(movie).State = EntityState.Modified;
        }

        public void SaveChanges(){
            this._context.SaveChanges();
        }
    }
}