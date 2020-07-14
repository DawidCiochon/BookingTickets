using System.Net.Http.Headers;
using System;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using BookingTickets.Models;
using System.Collections.Generic;
using System.Linq;
using BookingTickets.Data;
using AutoMapper;
using BookingTickets.DTOs;

namespace BookingTickets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly MovieRepository _repo;
        private readonly IMapper _mapper;
        public MovieController(MovieRepository repository, IMapper mapper)
        {
            this._repo = repository;
            this._mapper = mapper;
        } 

        [HttpGet("{id}")]
        public ActionResult <MovieDTO> GetMovieDetails(int id){
            var movie = _repo.GetMovieById(id);
            if(movie != null){
                return Ok(_mapper.Map<MovieDTO>(movie));
            }
            return NotFound();
        }

        [HttpGet]
        public ActionResult <IEnumerable<MovieDTO>> GetMovieRecords(){
            var movies = _repo.GetMovies();
            return Ok(_mapper.Map<IEnumerable<MovieDTO>>(movies));
        }

        [HttpPost]
        public ActionResult <MovieDTO> CreateMovie(MovieCreateDTO movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);
            _repo.InsertMovie(movie);
            _repo.SaveChanges();

            var movieReadDto = _mapper.Map<MovieDTO>(movie);

            return Ok(movieReadDto);
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