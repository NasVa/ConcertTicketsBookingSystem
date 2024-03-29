﻿using ConcertTicketsBookingSystem.Data.Interfaces;
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

        public async Task<List<Concert>> GetAllAsync(string search, byte page)
        {
            int concertsByPage = 5;
            return await context.concerts
              .OrderByDescending(concert => concert.dataTime)
              .Where(i => i.name.Contains(search != null ? search : ""))
              .Skip((page-1)* concertsByPage)
              .Take(concertsByPage)
              .ToListAsync();
        }

        public async Task<List<Concert>> GetByTypeAsync(string type, string search)
        {
            return await context.concerts.Where(concert => concert.Discriminator == type + "Concert")
                .Where(i => i.name.Contains(search != null ? search : ""))
                .ToListAsync();
        }

        public async Task<Concert> GetByIdAsync(int id)
        {
            return await context.concerts.FindAsync(id);
        }

        public List<string> GetConcertTypes()
        {
            return Enum.GetNames(typeof(concertType)).ToList();
        }
        public async Task UpdateAsync(Concert concert)
        {
            //context.Entry(concert).State = EntityState.Modified;
            //context.concerts.Update(concert);
            await context.SaveChangesAsync();
        }
    }
}
