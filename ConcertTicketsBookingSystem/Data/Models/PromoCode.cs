using ConcertTicketsBookingSystem.Models.Concerts;

namespace ConcertTicketsBookingSystem.Models
{
    public class PromoCode
    {
        public int Id { get; set; }
        public string Code { get; set; }

        public int ConcertId { get; set; }
        public Concert Concert { get; set; }
        public byte ProcentNum { get; set; }
    }
}
