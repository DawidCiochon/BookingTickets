using BookingTickets.Models;

namespace BookingTickets.Data
{
    public class SeanceRepository
    {
        private readonly BookingTicketsContext _context;
        public SeanceRepository(BookingTicketsContext context){
            this._context = context;
        }   

        public IEnumerable<Seance> GetSeances()
        {
            return this._context.Seances.ToList();
        }

        public Seance GetSeanceById(int seanceId){
            return this._context.Seances.FirstOrDefault(s => s.Id == seanceId);
        }

        public void InsertSeance(Seance seance){
            if(seance == null){
                throw new ArgumentNullException(nameof(seance));
            }
            this._context.Seances.Add(seance);
        }

        public void DeleteSeance(Seance seance){
            if(seance == null){
                throw new ArgumentNullException(nameof(seance));
            }
            this._context.Seances.Remove(seance);
        }

        public void UpdateSeance(Seance seance){
            //this._context.Entry(movie).State = EntityState.Modified;
        }

        public void SaveChanges(){
            this._context.SaveChanges();
        }
    }
}