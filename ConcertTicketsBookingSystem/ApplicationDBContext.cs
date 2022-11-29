using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ConcertTicketsBookingSystem.Models.Roles;
using ConcertTicketsBookingSystem.Models;
using ConcertTicketsBookingSystem.Models.Concerts;
using Microsoft.EntityFrameworkCore.Design;
using Fluent.Infrastructure.FluentModel;
using System.Data.Entity;

namespace ConcertTicketsBookingSystem
{
    public class ApplicationDBContext : System.Data.Entity.DbContext
    {
        public ApplicationDBContext()
            
        {
            
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }*/

        public System.Data.Entity.DbSet<User> users { get; set; }
        public System.Data.Entity.DbSet<Admin> admins { get; set; }
        public System.Data.Entity.DbSet<Ticket> tickets { get; set; }
        public System.Data.Entity.DbSet<PromoCode> promoCodes { get; set; }

        public System.Data.Entity.DbSet<Concert> concerts { get; set; }

    }

    /*public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }*/
}
