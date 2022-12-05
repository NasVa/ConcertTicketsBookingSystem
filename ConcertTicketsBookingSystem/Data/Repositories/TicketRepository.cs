using ConcertTicketsBookingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ConcertTicketsBookingSystem.Data.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDBContext context;

        public TicketRepository(ApplicationDBContext _context)
        {
            context = _context;
        }
        public async Task CreateAsync(Ticket ticket)
        {
            context.tickets.Add(ticket);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Ticket ticket)
        {
            context.tickets.Remove(ticket);
            await context.SaveChangesAsync();
        }

        public async Task<List<Ticket>> GetAllAsync()
        {
            return await context.tickets
                .OrderByDescending(ticket => ticket.Concert.dataTime)
                .ToListAsync(); 
        }

        public async Task UpdateAsync(Ticket ticket)
        {
            //context.tickets.Update(ticket);
            //context.Entry(ticket).State = Modified;
            await context.SaveChangesAsync();
        }
    }
}
