using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Authentication;
using Infrastructure.Data.Repositories;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependecyInjection
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<FrazzesPlatslageriDB>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<ICrudRepository<User>, UserRepository>();
            services.AddScoped<IJwtProvider, JwtProvider>();

            return services;
        }
    }
}
