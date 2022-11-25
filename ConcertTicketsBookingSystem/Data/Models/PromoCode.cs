using ConcertTicketsBookingSystem.Models.Concerts;

namespace ConcertTicketsBookingSystem.Models
{
    public class PromoCode
    {
        private int Id { get; set; }
        private string Code { get; set; }

        public int ConcertId { get; set; }
        private Concert Concert { get; set; }
        private byte ProcentNum { get; set; }
    }
}
