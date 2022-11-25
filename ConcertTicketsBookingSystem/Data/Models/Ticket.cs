using ConcertTicketsBookingSystem.Models.Concerts;
using ConcertTicketsBookingSystem.Models.Roles;

namespace ConcertTicketsBookingSystem.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int ConcertId { get; set; }
        public Concert Concert { get; set; }
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public State State { get; set; }
        public float Price { get; set; }
    }
}

public enum State
{
    Booked,
    Bought
}