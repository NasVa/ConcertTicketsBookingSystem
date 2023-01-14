using ConcertTicketsBookingSystem.Data.Interfaces;
using ConcertTicketsBookingSystem.Data.Repositories;
using ConcertTicketsBookingSystem.Models;
using ConcertTicketsBookingSystem.Models.Concerts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConcertTicketsBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IConcertRepository concertRepository;
        private ITicketRepository ticketRepository;

        public HomeController(IConcertRepository concertRepository, ITicketRepository _ticketRepository)
        {
            this.concertRepository = concertRepository;
            ticketRepository = _ticketRepository;
        }

        [HttpGet]
        public async Task<List<Concert>> Index(string type)
             
        {
            var concerts = type == "All" ? await concertRepository.GetAllAsync() : await concertRepository.GetByTypeAsync(type);
            return concerts;
        }
        [HttpGet("{id}")]
        public async Task<Concert> GetConcert(int id)
        {
            return await concertRepository.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task Post()
        {
            /*var concert = new PartyConcert
            {
                id = 1,
                name = "Dvizh",
                ticketsNum = 100,
                address = "Minsk",
                ageLimit = 18,
                dataTime = DateTime.Now,
                performer = "DanaMoll"
            };
            await concertRepository.CreateAsync(concert);*/
            var ticket = new Ticket
            {
                //Id = 1,
                ConcertId = 1,
                Concert = null,
                //OwnerId = 1,
                Owner = null,
                State = State.Booked,
                Price = 6
            };
            await ticketRepository.CreateAsync(ticket);
        }
    }
}
