using bruno.CatalogFilms.API.Core.User;
using bruno.CatalogFilms.Application.CatalogFilms.Commands;
using bruno.CatalogFilms.Application.CatalogFilms.Commands.Handlers;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace bruno.CatalogFilms.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInjection).Assembly;

            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);
             
            services.AddScoped<IRequestHandler<CreateCatalogFilmsCommand, ValidationResult>, CreateCatalogFilmsCommandHandler>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }

    }
}
