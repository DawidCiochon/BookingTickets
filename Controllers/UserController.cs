using System.Net.Http.Headers;
using System;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using BookingTickets.Models;
using System.Collections.Generic;
using System.Linq;
using BookingTickets.Data;

namespace BookingTickets.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User, UserRepository>
    {
        //private readonly BookingTicketsContext _context;

        public UserController(UserRepository repository) : base(repository)
        {
            
        }

        [AllowAnonymus]
        [HttpPost("authenticate")]
        public IAsyncResult Authenticate([FromBody]AuthenticateRequest model)
        {
            
        }

        /*[HttpPost]
        public IActionResult Create([FromBody]User user){
            if(ModelState.IsValid){
                Guid guid = Guid.NewGuid();
                user.Id = Convert.ToInt32(guid);
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public User GetUserDetails(int id){
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        [HttpGet]
        public IEnumerable<User> GetUserRecords(){
            return _context.Users.ToList();
        }

        [HttpPut]
        public IActionResult Edit([FromBody]User user){
            if(ModelState.IsValid){
                _context.Users.Update(user);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            var data = _context.Users.FirstOrDefault(u => u.Id == id);
            if(data == null){
                return NotFound();
            }
            _context.Users.Remove(data);
            _context.SaveChanges();
            return Ok();
        }*/
    }
}