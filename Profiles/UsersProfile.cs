using AutoMapper;
using BookingTickets.DTOs;
using BookingTickets.Models;

namespace BookingTickets.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile(){
            CreateMap<User, UserDTO>();
            CreateMap<UserCreateDTO, User>();
        }
    }
}