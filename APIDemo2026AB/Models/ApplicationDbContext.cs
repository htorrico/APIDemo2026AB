using Microsoft.EntityFrameworkCore;

namespace APIDemo2026AB.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
           DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        
        public DbSet<Category> Categories { get; set; }

    }
}
