using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure (this IServiceCollection services)
        {
            services.AddScoped<ICrudRepository<User>, UserRepository>();

            return services;
        }
    }
}
