using Minimal.Mappins;

namespace Minimal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {}
        
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeAddress> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeMap());
            modelBuilder.ApplyConfiguration(new EmployeeAddressMap());                                  
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            /// Define all string propertis limited max 100 caracters 
            configurationBuilder.Properties<string>()
            .HaveMaxLength(100);

            base.ConfigureConventions(configurationBuilder);
        }

    }
}