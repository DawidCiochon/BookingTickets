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
    public class SeatController : ControllerBase
    {
        private readonly SeatRepository _repo;
        public SeatController(SeatRepository repository)
        {
            this._repo = repository;
        } 

        [HttpGet("{id}")]
        public ActionResult <Seat> GetSeatDetails(int id){
            var seat = _repo.GetSeatById(id);
            if(seat != null){
                return Ok(seat);
            }
            return NotFound();
        }

        [HttpGet]
        public ActionResult <IEnumerable<Seat>> GetMovieRecords(){
            var seats = _repo.GetSeats();
            return Ok(seats);
        }

        [HttpPost]
        public ActionResult <Seat> CreateMovie(Seat seat)
        {
            _repo.InsertSeat(seat);
            _repo.SaveChanges();

            return Ok(seat);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateSeat(int id, Seat seat)
        {
            var seat1 = _repo.GetSeatById(id);
            if(seat1 == null){
                return NotFound();
            }

            _repo.UpdateSeat(seat);
            _repo.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteSeat(int id)
        {
            var seat = _repo.GetSeatById(id);
            if(seat == null){
                return NotFound();
            }
            _repo.DeleteSeat(seat);
            _repo.SaveChanges();

            return NoContent();
        }
    }
}