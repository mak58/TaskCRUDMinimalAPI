using Microsoft.EntityFrameworkCore;
using Minimal.Models;

namespace Minimal.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Tasks> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("DataSource=app.db;Cache=Shared");
        
    }
}