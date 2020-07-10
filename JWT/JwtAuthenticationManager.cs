using System.Security.Cryptography;
using System;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using BookingTickets.Models;
using Microsoft.IdentityModel.Tokens;

namespace BookingTickets.JWT
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly BookingTicketsContext _context;
        private readonly string _key;
        public JwtAuthenticationManager(string key){
            this._key = key;
        }
        public JwtAuthenticationManager(BookingTicketsContext context, string key)
        {
            this._context = context;
            this._key = key;
        }
        public string Authenticate(string userEmail, string password)
        {
            if(!_context.Users.Any(u => u.Email == userEmail && u.Password == password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userEmail)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = 
                    new SigningCredentials(
                        new SymmetricSecurityKey(tokenKey),
                        SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
