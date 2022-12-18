namespace ConcertTicketsBookingSystem.Models.Concerts
{
    public abstract class Concert
    {
        public int id { get; set; }
        public string name { get; set; }
        public string performer { get; set; }
        public int ticketsNum { get; set; }
        public DateTime dataTime { get; set; }
        public string address { get; set; }

    }
}

public enum concertType
{
    Classic,
    Party,
    OpenAir
}

