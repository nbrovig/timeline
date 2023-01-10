using Microsoft.EntityFrameworkCore;

namespace timeline.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}
