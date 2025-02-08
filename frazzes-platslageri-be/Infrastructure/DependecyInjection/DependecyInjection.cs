using Domain.Interface;
using Infrastructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure (this IServiceCollection services)
        {
            services.AddScoped<ICrudRepository, UserRepository>();

            return services;
        }
    }
}
