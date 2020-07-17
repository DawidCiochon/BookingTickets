using System;
using System.Collections.Generic;
using System.Linq;
using BookingTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.Data
{
    public class RoomRepository
    {
        private readonly BookingTicketsContext _context;
        
        public RoomRepository(BookingTicketsContext context){
            this._context = context;
        }   

        public IEnumerable<Room> GetRooms()
        {
            return this._context.Rooms.ToList();
        }

        public Room GetRoomById(int userId){
            return this._context.Rooms.Find(userId);
        }

        public void InsertRoom(Room room){
            if(room == null){
                throw new ArgumentNullException(nameof(room));
            }
            this._context.Rooms.Add(room);
        }

        public void DeleteRoom(Room room)
        {
            //Room room = this._context.Rooms.Find(roomId);
            this._context.Rooms.Remove(room);
        }

        public void UpdateRoom(Room room){
            this._context.Entry(room).State = EntityState.Modified;
        }

        public void SaveChanges(){
            this._context.SaveChanges();
        }
    }
}