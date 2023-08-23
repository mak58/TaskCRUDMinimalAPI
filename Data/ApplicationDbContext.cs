using Microsoft.EntityFrameworkCore;
using Minimal.Interfaces;
using Minimal.Models;

namespace Minimal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {}
        
        public DbSet<Tasks> Tasks { get; set; }
    }
}