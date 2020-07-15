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
    public class SeanceController : ControllerBase
    {
        private readonly SeanceRepository _repo;
        private readonly IMapper _mapper;
        public MovieController(SeanceRepository repository, IMapper mapper)
        {
            this._repo = repository;
            this._mapper = mapper;
        } 

        [HttpGet("{id}")]
        public ActionResult <Seance> GetSeanceDetails(int id){
            var seance = _repo.GetSeanceById(id);
            if(seance != null){
                return Ok(seance);
            }
            return NotFound();
        }

        [HttpGet]
        public ActionResult <IEnumerable<Seance>> GetSeanceRecords(){
            var seances = _repo.GetSeances();
            return Ok(seances);
        }

        [HttpPost]
        public ActionResult <Seance> CreateSeance(Movie movie, Room room, DateTime date)
        {
            var movieId = movie.Id;
            var roomId = room.Id;
            Seance seance = new Seance{
                StartDate = date,
                MovieId = movieId,
                RoomId = roomId
            };
            _repo.InsertSeance(seance);
            _repo.SaveChanges();

            return Ok(seance);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateMovie(int id, MovieCreateDTO movieUpdateDto)
        {
            var movieModel = _repo.GetMovieById(id);
            if(movieModel == null){
                return NotFound();
            }

            _mapper.Map(movieUpdateDto, movieModel);
            _repo.UpdateMovie(movieModel);
            _repo.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMovie(int id)
        {
            var movieModel = _repo.GetMovieById(id);
            if(movieModel == null){
                return NotFound();
            }
            _repo.DeleteMovie(movieModel);
            _repo.SaveChanges();

            return NoContent();
        }
    }
}