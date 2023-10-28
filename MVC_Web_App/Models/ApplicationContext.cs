using Microsoft.EntityFrameworkCore;

namespace MVC_Web_App.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Tool> Tools { get; set; } = null!;
        public DbSet<Tool_type> Tool_types { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
