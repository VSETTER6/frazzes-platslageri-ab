using Application.Abbstractions;
using Domain.Models;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependecyInjection
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependecyInjection).Assembly;

            services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);

            return services;
        }
    }
}
