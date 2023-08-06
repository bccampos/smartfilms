using bruno.CatalogFilms.Infrastructure.Data;
using bruno.WebApi.Common.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using bruno.CatalogFilms.API.Core.Identity;
using bruno.CatalogFilms.API.Core.User;

namespace bruno.CatalogFilms.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();


            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddMappings();    
            services.AddDbContext<CatalogFilmsDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(name: "DefaultConnection")));

            services.AddJwtConfiguration(configuration);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Catalog Films API",
                    Description = "My Project for Catalog Films.",
                    Contact = new OpenApiContact() { Name = "Bruno Campos", Email = "brunimdmly@gmail.com" }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Insert token JWT like that: Bearer {your token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });

            });

            return services;
        }

    }
}
