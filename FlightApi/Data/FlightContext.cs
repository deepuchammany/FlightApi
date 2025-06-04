using FlightApi.Models;
using Microsoft.EntityFrameworkCore;
namespace FlightApi.Data
{
    public class FlightContext : DbContext
    {
        public FlightContext(DbContextOptions<FlightContext> options) : base(options) { }
        public DbSet<Flight> Flights { get; set; }
    }
}