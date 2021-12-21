using Microsoft.EntityFrameworkCore;

namespace Lab8.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Models.Student> Students { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
