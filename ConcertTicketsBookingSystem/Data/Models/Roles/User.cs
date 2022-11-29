using Microsoft.AspNetCore.Identity;

namespace ConcertTicketsBookingSystem.Models.Roles
{
    public class User : IdentityUser
    {
        public int Id {get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Ticket> Tickets { get; set; }

        //booking ticket
        //buying ticket
    }
}
