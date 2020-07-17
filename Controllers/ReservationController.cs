using System;
using System.Collections.Generic;
using BookingTickets.Data;
using BookingTickets.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationRepository _repo;
        public ReservationController(ReservationRepository repository)
        {
            this._repo = repository;
        } 

        [HttpGet("{id}")]
        public ActionResult <Reservation> GetReservationDetails(int id){
            var reservations = _repo.GetReservationById(id);
            if(reservations != null){
                return Ok(reservations);
            }
            return NotFound();
        }

        [HttpGet]
        public ActionResult <IEnumerable<Reservation>> GetReservationRecords(){
            var reservations = _repo.GetReservations();
            return Ok(reservations);
        }

        [HttpPost]
        public ActionResult <Reservation> CreateReservation([FromBody] Reservation reservation)
        {
            _repo.InsertReservation(reservation);
            _repo.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateReservation(int id, Reservation reservation)
        {
            var reservation1 = _repo.GetReservationById(id);
            if(reservation1 == null){
                return NotFound();
            }

            _repo.UpdateReservation(reservation);
            _repo.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteReservation(int id)
        {
            var reservation = _repo.GetReservationById(id);
            if(reservation == null){
                return NotFound();
            }
            else
            {
                if(_repo.DeleteReservation30minBefore(reservation))
                {
                    _repo.DeleteReservation(reservation);
                    _repo.SaveChanges();
                }
                else{
                    BadRequest();
                }
            }
            return NoContent();
        }
    }
}