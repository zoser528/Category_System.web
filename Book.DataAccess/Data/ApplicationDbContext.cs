using Book.Models;
using Microsoft.EntityFrameworkCore;

namespace Book.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {

        }

        public DbSet<Categorey> Categories { get; set; }
    }
}
