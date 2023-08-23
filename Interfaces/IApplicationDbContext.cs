using Microsoft.EntityFrameworkCore;
using Minimal.Models;

namespace Minimal.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Tasks> Tasks { get; set; }

        Task<int> SaveChangesAsync();
    }
}