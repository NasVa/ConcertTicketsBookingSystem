using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ConcertTicketsBookingSystem.Models.Roles;
using ConcertTicketsBookingSystem.Models;

namespace ConcertTicketsBookingSystem.Data
{
    public class ApplicationDBContext : ApiAuthorizationDbContext<User>
    {
        public ApplicationDBContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationsStoreOptions)
            :base(options,operationsStoreOptions)
        {       
        }

        DbSet<User> users { get; set; }
        DbSet<Admin> admins { get; set; }
        DbSet<Ticket> tickets { get; set; }
        DbSet<PromoCode> promoCodes { get; set; }
        
    }
}
