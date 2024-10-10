using Microsoft.EntityFrameworkCore;
using MovieTracker.Models;

namespace MovieTracker.Add
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
    }
}
