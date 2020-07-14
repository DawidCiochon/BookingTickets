using AutoMapper;
using BookingTickets.DTOs;
using BookingTickets.Models;

namespace BookingTickets.Profiles
{
    public class SeanceProfile : Profile
    {
        public SeanceProfile(){
            CreateMap<Seance, SeanceDTO>();
        }
    }
}