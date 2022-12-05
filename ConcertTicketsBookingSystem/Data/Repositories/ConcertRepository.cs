using ConcertTicketsBookingSystem.Data.Interfaces;
using ConcertTicketsBookingSystem.Models.Concerts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace ConcertTicketsBookingSystem.Data.Repositories
{
    public class ConcertRepository : IConcertRepository
    {
        private readonly ApplicationDBContext context;
        private readonly IMemoryCache memoryCache; 

        public ConcertRepository(ApplicationDBContext _context)
        {
            context = _context;
        }
        public async Task CreateAsync(Concert concert)
        {
            context.concerts.Add(concert);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Concert concert)
        {
            //context.concerts.Remove(concert);
            await context.SaveChangesAsync();
        }

        public async Task<List<Concert>> GetAllAsync()
        {
            return await context.concerts
              .OrderByDescending(concert => concert.dataTime)
            .ToListAsync();
        }

        public async Task<Concert> GetByIdAsync(int id)
        {
            return await context.concerts.FindAsync(id);
        }

        public async Task UpdateAsync(Concert concert)
        {
            //context.Entry(concert).State = EntityState.Modified;
            //context.concerts.Update(concert);
            await context.SaveChangesAsync();
        }
    }
}
