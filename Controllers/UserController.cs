 using System.Reflection.Metadata;
using System.Net.Http.Headers;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BookingTickets.Models;
using System.Linq;
using BookingTickets.Data;
using Microsoft.AspNetCore.Authorization;
using BookingTickets.JWT;
using System.Threading.Tasks;
using System.Web.Http;
using BookingTickets.DTOs;
using AutoMapper;

namespace BookingTickets.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        private readonly UserRepository _repo;
        private readonly IMapper _mapper;
        public UserController(UserRepository repository, 
                            IJwtAuthenticationManager jwtAuthenticationManager,
                            IMapper mapper)
        {
            this._jwtAuthenticationManager = jwtAuthenticationManager;
            this._repo = repository;
            this._mapper = mapper;
        }


        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            var token = _jwtAuthenticationManager.Authenticate(userCred.UserEmail, userCred.Password);
            if(token == null) return Unauthorized();
            return Ok(token);
;       }

        [HttpPost]
        public ActionResult <UserDTO> CreateUser(UserCreateDTO userCreateDto)
        {
            var user = _mapper.Map<User>(userCreateDto);
            _repo.InsertUser(user);
            _repo.SaveChanges();

            var userReadDto = _mapper.Map<UserDTO>(user); 

            return Ok(userReadDto);
        }

        [HttpGet("{id}")]
        public ActionResult <User> GetUserDetails(int id){
            var user = _repo.GetUserById(id);
            return Ok(user);
        }

        [HttpGet]
        public ActionResult <IEnumerable<User>> GetUserRecords(){
            var users = _repo.GetUsers();
            return Ok(users);
        }

        /*[HttpPut]
        public IActionResult Edit([FromBody]User user){
            if(ModelState.IsValid){
                _context.Users.Update(user);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        /*[HttpDelete("{id}")]
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