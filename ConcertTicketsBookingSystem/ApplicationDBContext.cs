
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ConcertTicketsBookingSystem.Models.Roles;
using ConcertTicketsBookingSystem.Models;
using ConcertTicketsBookingSystem.Models.Concerts;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ConcertTicketsBookingSystem
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
            
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

        public DbSet<User> users { get; set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Ticket> tickets { get; set; }
        public DbSet<PromoCode> promoCodes { get; set; }

        public DbSet<Concert> concerts { get; set; }

        public DbSet<ClassicConcert> classicConcerts { get; set; }
        public DbSet<PartyConcert> partyConcerts { get; set; }
        public DbSet<OpenAirConcert> openAirConcerts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Concert>();
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Ticket[] tickets = new Ticket[10];
            for (int i = 0; i < tickets.Length; i++)
            {
                tickets[i].Concert = new PartyConcert();
                tickets[i].Price = 100;
                tickets[i].ConcertId = i;
            }
            modelBuilder.Entity<Ticket>().HasData(tickets);
        }*/


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
