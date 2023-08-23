namespace Minimal.Services
{
    /// <summary>
    /// This static class receive the Database ConnectionInterfaces and Depedency Injection of Interfaces and classes. 
    /// Dependency Injection is being declared here, avoiding overload the program.cs
    /// </summary>
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(
            this IServiceCollection services,
            IConfiguration configuration) 
        {           
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("Database")));

            services.AddScoped<ITaskRepositories, TaskRepositories>();

            return services;            
        }        
    }
}