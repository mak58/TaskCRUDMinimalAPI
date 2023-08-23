using Microsoft.EntityFrameworkCore;
using Minimal.Data;
using Minimal.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Minimal.Services
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services) 
        {           

            return services;            
        }
        
    }
}