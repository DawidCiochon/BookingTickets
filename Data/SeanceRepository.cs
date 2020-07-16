using BookingTickets.Models;
using System.Collections.Generic;
using System.Linq;
using System;

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

        public IEnumerable<Seance> GetSeanceByMovieId(int id)
        {
            return this._context.Seances.Where(s => s.MovieId == id).ToList();
        }

        

        public object InsertSeance(Room room, Movie movie, DateTime date){
            var seance = new Seance(){
                StartDate = date,
                MovieId = movie.Id,
                RoomId = room.Id
            };
            if(seance == null){
                throw new ArgumentNullException(nameof(seance));
                return null;
            }
            this._context.Seances.Add(seance);
            return seance;
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