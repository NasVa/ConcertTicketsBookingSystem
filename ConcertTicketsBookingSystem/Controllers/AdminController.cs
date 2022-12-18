using ConcertTicketsBookingSystem.Data.Interfaces;
using ConcertTicketsBookingSystem.Models.Concerts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConcertTicketsBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IConcertRepository concertRepository;

        public AdminController(IConcertRepository concertRepository)
        {
            this.concertRepository = concertRepository;
        }

        [HttpPost("concert/create")]
        public async Task CreateConcert([FromForm] IFormCollection formData)
        {
            var concert = new PartyConcert
            {
                //id = 1,
                name = "Dvizh",
                ticketsNum = 100,
                address = "Minsk",
                ageLimit = 18,
                dataTime = DateTime.Now,
                performer = "DanaMoll"
            };
            await concertRepository.CreateAsync(concert);           
            //await concertRepository.CreateAsync(concert);
        }

        [HttpGet]
        public async Task GetConcertTypes()
        {
            List<string> types = concertRepository.GetConcertTypes();
        }
    }
}
