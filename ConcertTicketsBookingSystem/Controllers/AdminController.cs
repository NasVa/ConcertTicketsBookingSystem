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

            var concert = new PartyConcert
            {
                name = formData["name"],
                ticketsNum = int.Parse(formData["ticketsNum"]),
                address = formData["address"],
                ageLimit = 18,
                dataTime = Convert.ToDateTime(formData["data"] + " " + formData["time"]),
                performer = formData["performer"]
            };
            /*var concert = new PartyConcert
            {
                //id = 1,
                name = "Dvizh",
                ticketsNum = 100,
                address = "Minsk",
                ageLimit = 18,
                dataTime = DateTime.Now,
                performer = "DanaMoll"
            };*/
            await concertRepository.CreateAsync(concert);
            return "Ok";
            //await concertRepository.CreateAsync(concert);
        }

        [HttpGet]
        public async Task GetConcertTypes()
        {
            List<string> types = concertRepository.GetConcertTypes();
        }
    }
}
