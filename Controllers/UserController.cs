using System.Net;
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
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using BookingTickets.Helpers;

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
        //private UserManager<User> _userManager;
        //private SignInManager<User> _signInManager;
        private readonly AppSettings _appSettings;
        public UserController(UserRepository repository, 
                            IJwtAuthenticationManager jwtAuthenticationManager,
                            IMapper mapper,
                            /*UserManager userManager,
                            SignInManager signInManager,*/
                            IOptions<AppSettings> appSettings)
        {
            this._jwtAuthenticationManager = jwtAuthenticationManager;
            this._repo = repository;
            this._mapper = mapper;
            //this._userManager = userManager;
            //this._signInManager = signInManager;
            this._appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCred userCred)
        {
            var token = _jwtAuthenticationManager.Authenticate(userCred.Email, userCred.Password);
            if(token == null) return Unauthorized();
            return Ok(new {token});
        }

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

        [HttpGet("usersbyseance/{id}")]
        public ActionResult <IEnumerable<User>> GetUserBySeanceId(int id)
        {
            var users = _repo.GetUsersBySeanceId(id);
            return Ok(users);
        }

        /*[HttpGet("userprofile")]
        [Authorize]
        // /api/userprofile
        public Task<Object> GetUserProfile(){
            var UserId = 
        }*/

        [HttpPut("{id}")]
        public IActionResult Edit(int id, User user){
            var userModel = _repo.GetUserById(id);
            if(userModel == null){
                return NotFound();
            }

            _repo.UpdateUser(user);
            _repo.SaveChanges();

            return NoContent();
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