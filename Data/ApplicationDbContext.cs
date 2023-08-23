namespace Minimal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {}
        
        public DbSet<Tasks> Tasks { get; set; }
    }
}