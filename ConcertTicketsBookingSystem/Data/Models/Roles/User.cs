namespace ConcertTicketsBookingSystem.Models.Roles
{
    public class User
    {
        private int Id {get; set; }
        private string Name { get; set; }
        private string Surname { get; set; }
        private List<Ticket> Tickets { get; set; }

        //booking ticket
        //buying ticket
    }
}
