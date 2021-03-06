using System.Runtime.Intrinsics.X86;
using BookingTickets.Models;
using System.Collections.Generic;
using System;
using System.Linq;

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
            return this._context.Reservations.FirstOrDefault(r => r.Id == reservationId);
        }

        public IEnumerable<Reservation> GetReservationsBySeanceId(int id)
        {
            return this._context.Reservations.Where(r => r.SeanceId == id);
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