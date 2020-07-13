using System;
using BookingTickets.Models;
using System.Runtime;
using System.Linq;

namespace BookingTickets.Data
{
    public class UserRepository : Repository<User, BookingTicketsContext>
    {
        private readonly BookingTicketsContext _context;
        public UserRepository(BookingTicketsContext context) : base(context){
            this._context = context;
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
