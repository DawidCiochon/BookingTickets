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
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController// : BaseController<Movie, MovieRepository>
    {
        private readonly BookingTicketsContext _context;
        public MovieController(/*MovieRepository repository, */BookingTicketsContext context)// : base(repository)
        {
            this._context = context;
        } 

        public ICollection<Movie> GetAllMovies(){
            return this._context.Movies.ToList();
        }
    }
}