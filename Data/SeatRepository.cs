using System;
using System.Collections.Generic;
using System.Linq;
using BookingTickets.Models;

namespace BookingTickets.Data
{
    public class SeatRepository
    {
        private readonly BookingTicketsContext _context;
        public SeatRepository(BookingTicketsContext context){
            this._context = context;
        }   

        public IEnumerable<Seat> GetSeats()
        {
            return this._context.Seats.ToList();
        }

        public Seat GetSeatById(int seatId){
            return this._context.Seats.FirstOrDefault(m => m.Id == seatId);
        }

        public void InsertSeat(Seat seat){
            this._context.Seats.Add(seat);
        }

        public void DeleteSeat(Seat seat){
            if(seat == null){
                throw new ArgumentNullException(nameof(seat));
            }
            this._context.Seats.Remove(seat);
        }

        public void UpdateSeat(Seat seat){
            //this._context.Entry(movie).State = EntityState.Modified;
        }

        public void SaveChanges(){
            this._context.SaveChanges();
        }
    }
}