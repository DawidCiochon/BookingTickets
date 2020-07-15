using System.Security.Cryptography;
using System;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using BookingTickets.Models;
using Microsoft.IdentityModel.Tokens;
using BookingTickets.Helpers;
using Microsoft.Extensions.Options;

namespace BookingTickets.JWT
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly BookingTicketsContext _context;
        private readonly AppSettings _appSettings;
        //private readonly string _key;

        public JwtAuthenticationManager(IOptions<AppSettings> appSettings, BookingTicketsContext context)
        {
            this._appSettings = appSettings.Value;
            this._context = context;
        }
        public string Authenticate(string userEmail, string password)
        {
            //var user1 = _context.Users.SingleOrDefault(u => u.Email == userEmail && u.Password == password);
            
            //if(user1==null) return null;
            if(!_context.Users.Any(u => u.Email == userEmail && u.Password == password))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, userEmail)
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
