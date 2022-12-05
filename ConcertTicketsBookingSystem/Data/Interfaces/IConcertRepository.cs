using ConcertTicketsBookingSystem.Models.Concerts;

namespace ConcertTicketsBookingSystem.Data.Interfaces
{
    public interface IConcertRepository
    {
        Task CreateAsync(Concert concert);

        Task UpdateAsync(Concert concert);

        Task<List<Concert>> GetAllAsync();

        Task<Concert> GetByIdAsync(int id);

        Task DeleteAsync(Concert concert);
    }
}
