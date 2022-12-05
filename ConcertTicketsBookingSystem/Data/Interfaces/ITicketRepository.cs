using ConcertTicketsBookingSystem.Models;

namespace ConcertTicketsBookingSystem.Data.Repositories
{
    public interface ITicketRepository
    {

        Task CreateAsync(Ticket ticket);

        Task UpdateAsync(Ticket ticket);

        Task<List<Ticket>> GetAllAsync();

        Task DeleteAsync(Ticket ticket);

    }
}
