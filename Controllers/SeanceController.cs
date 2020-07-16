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
        public SeanceController(SeanceRepository repository)
        {
            this._repo = repository;
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

        [HttpGet("seancesbymovie/{id}")]
        public ActionResult <IEnumerable<Seance>> GetSeancesByMovieId(int id){
            var seances = _repo.GetSeanceByMovieId(id);
            return Ok(seances);
        }

        /*[HttpPost]
        public ActionResult <Seance> CreateSeance([FromBody] DateTime date, Movie movie, Room room)
        {
            _repo.InsertSeance(room, movie, date);
            _repo.SaveChanges();

            return Ok();
        }*/

        [HttpPut("{id}")]
        public ActionResult UpdateSeance(int id, Seance seance)
        {
            var seance_1 = _repo.GetSeanceById(id);
            if(seance_1 == null){
                return NotFound();
            }

            _repo.UpdateSeance(seance_1);
            _repo.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSeance(int id)
        {
            var seanceModel = _repo.GetSeanceById(id);
            if(seanceModel == null){
                return NotFound();
            }
            _repo.DeleteSeance(seanceModel);
            _repo.SaveChanges();

            return NoContent();
        }
    }
}