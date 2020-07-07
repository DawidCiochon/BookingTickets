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
    public class SeatController : BaseController<Seat, SeatRepository>
    {
        public SeatController(SeatRepository repository) : base(repository)
        {
            
        } 
    }
}