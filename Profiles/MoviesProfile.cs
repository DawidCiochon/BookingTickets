using AutoMapper;
using BookingTickets.DTOs;
using BookingTickets.Models;

namespace BookingTickets.Profiles
{
    public class MoviesProfile : Profile
    {
        public MoviesProfile(){
            CreateMap<Movie, MovieDTO>();
            CreateMap<MovieCreateDTO, Movie>();
        }
    }
}