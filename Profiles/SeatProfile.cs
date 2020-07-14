using AutoMapper;
using BookingTickets.DTOs;
using BookingTickets.Models;

namespace BookingTickets.Profiles
{
    public class SeatProfile : Profile
    {
        public SeatProfile(){
            CreateMap<Seat, SeatDTO>();
        }
    }
}