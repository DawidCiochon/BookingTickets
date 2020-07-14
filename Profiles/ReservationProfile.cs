using AutoMapper;
using BookingTickets.DTOs;
using BookingTickets.Models;

namespace BookingTickets.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile(){
            CreateMap<Reservation, ReservationDTO>();
        }
    }
}