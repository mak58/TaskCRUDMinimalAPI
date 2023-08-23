namespace Minimal.Services
{
    /// <summary>
    /// This static class is waiting the applicationt to have a buisiness rule. 
    /// After that, the life cicle os Dependency Injection will be declared here, avoiding overload the program.cs
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