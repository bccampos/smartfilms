using bruno.Application.Common.Interfaces.Services;
using bruno.CatalogFilms.Domain.Interfaces.Persistence;
using bruno.CatalogFilms.Infrastructure.Data;
using bruno.CatalogFilms.Infrastructure.Persistence;
using bruno.CatalogFilms.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace bruno.CatalogFilms.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            //Config Identity
            //services.AddIdentity<IdentityUser, IdentityRole>()
            //       .AddEntityFrameworkStores<CatalogFilmsDbContext>()
            //       .AddDefaultTokenProviders();

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<ICatalogFilmsRepository, CatalogFilmsRepository>();

            return services;
        }

    }
}
