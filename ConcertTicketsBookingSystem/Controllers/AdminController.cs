using ConcertTicketsBookingSystem.Data.Interfaces;
using ConcertTicketsBookingSystem.Models.Concerts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConcertTicketsBookingSystem.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IConcertRepository concertRepository;

        public AdminController(IConcertRepository concertRepository)
        {
            this.concertRepository = concertRepository;
        }

        [HttpPost("concert/create")]
        public async Task<string> CreateConcert([FromForm] IFormCollection formData)
        {
            Concert concert = null;

            if (formData["concertType"] == "Classic") { 
                concert = new ClassicConcert
                {
                    compositor = formData["compositor"],
                    voiceType = formData["voiceType"]
                };
            }
            else if (formData["concertType"] == "Party")
            {
                concert = new PartyConcert
                {
                    ageLimit = byte.Parse(formData["ageLimit"])
                };
            }
            else
            {
                concert = new OpenAirConcert
                {
                    path = formData["path"],
                    headliner = formData["headliner"]
                };
            }
            concert.name = formData["name"];
            concert.ticketsNum = int.Parse(formData["ticketsNum"]);
            concert.address = formData["address"];
            concert.dataTime = Convert.ToDateTime(formData["data"] + " " + formData["time"]);
            concert.performer = formData["performer"];
            
            await concertRepository.CreateAsync(concert);
            return "Ok";
        }

        [HttpGet]
        public async Task GetConcertTypes()
        {
            List<string> types = concertRepository.GetConcertTypes();
        }
    }
}
