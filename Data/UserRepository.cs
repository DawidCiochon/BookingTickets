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
        public UserRepository(BookingTicketsContext context){
            this._context = context;
        }   

        public IEnumerable<User> GetUsers()
        {
            return this._context.Users.ToList();
        }

        public User GetUserById(int userId){
            return this._context.Users.Find(userId);
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
            this._context.Entry(user).State = EntityState.Modified;
        }

        public void SaveChanges(){
            this._context.SaveChanges();
        }

        /*public User Create(User user, string password)
        {
            if(string.IsNullOrWhiteSpace(password))
                throw new ApplicationException("Password is required");
            if(_context.Users.Any(x => x.Email == user.Email))
                throw new ApplicationException("Email: " + user.Email + " is already taken");

            byte[] passwordHash;
            CreatePassword
        }    
    }

    private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
 
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }*/
    }
}
