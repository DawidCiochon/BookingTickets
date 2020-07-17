using System;
using BookingTickets.Models;
using System.Runtime;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.Data
{
    public class UserRepository
    {
        private readonly BookingTicketsContext _context;
        private readonly ReservationRepository _rRepo;
        public UserRepository(BookingTicketsContext context,
                            ReservationRepository resRep){
            this._context = context;
            this._rRepo = resRep;
        }   

        public IEnumerable<User> GetUsers()
        {
            return this._context.Users.ToList();
        }

        public User GetUserById(int userId){
            return this._context.Users.Find(userId);
        }

        public IEnumerable<User> GetUsersBySeanceId(int id)
        {
            return this._context.Users.Where(u => u.Reservations.Any(r => r.SeanceId == id)).ToList();
        }

        public void InsertUser(User user){
            if(user == null){
                throw new ArgumentNullException(nameof(user));
            }
            this._context.Users.Add(user);
        }

        public void DeleteUser(int userId)
        {
            User user = this._context.Users.Find(userId);
            this._context.Users.Remove(user);
        }

        public void UpdateUser(User user){
            //this._context.Entry(user).State = EntityState.Modified;
        }

        public void SaveChanges(){
            this._context.SaveChanges();
        }

        public bool DoesUserWithMailExist(string email)
        {
            return this._context.Users.Any(user => user.Email == email);
        }

        
    }
}
