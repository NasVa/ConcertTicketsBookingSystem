namespace ConcertTicketsBookingSystem.Models.Concerts
{
    public abstract class Concert
    {
        private int id { get; set; }
        private string name { get; set; }
        private string performer { get; set; }
        private int ticketsNum { get; set; }
        private DateTime dataTime { get; set; }
        private string address { get; set; }
    }
}

public enum concertType
{
    Classic,
    Party,
    OpenAir
}
