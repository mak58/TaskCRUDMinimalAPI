using Microsoft.EntityFrameworkCore;
using Minimal.Models;

namespace Minimal.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Tasks> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=app.db; User=mk, Password = 123; Cache=Shared");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tasks>()
                .Property(x => x.Id).IsRequired();
        }

        
    }
}