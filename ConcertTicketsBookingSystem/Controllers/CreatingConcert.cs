using ConcertTicketsBookingSystem.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConcertTicketsBookingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreatingConcert : ControllerBase
    {
        private IConcertRepository concertRepository;

        public CreatingConcert(IConcertRepository concertRepository)
        {
            this.concertRepository = concertRepository;
        }
    }
}
