using System.Net.Http.Headers;
using System;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using BookingTickets.Models;
using System.Collections.Generic;
using System.Linq;
using BookingTickets.Data;
using Microsoft.Extensions.Options;


namespace BookingTickets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly RoomRepository _repo;
        public RoomController(RoomRepository repository)
        {
            this._repo = repository;
        } 

        [HttpGet("{id}")]
        public ActionResult <Room> GetRoomDetails(int id){
            var room = _repo.GetRoomById(id);
            if(room != null){
                return Ok(room);
            }
            return NotFound();
        }

        [HttpGet]
        public ActionResult <IEnumerable<Room>> GetRoomRecords(){
            var rooms = _repo.GetRooms();
            return Ok(rooms);
        }

        [HttpPost]
        public ActionResult <Room> CreateRoom(Room room)
        {
            _repo.InsertRoom(room);
            _repo.SaveChanges();

            return Ok(room);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateRoom(int id, Room room)
        {
            var room1 = _repo.GetRoomById(id);
            if(room1 == null){
                return NotFound();
            }
            _repo.UpdateRoom(room1);
            _repo.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRoom(int id)
        {
            var room = _repo.GetRoomById(id);
            if(room == null){
                return NotFound();
            }
            _repo.DeleteRoom(room);
            _repo.SaveChanges();

            return NoContent();
        }
    }
    
}