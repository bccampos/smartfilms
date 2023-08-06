using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using bruno.CatalogFilms.WebApp.MVC.Extensions;
using SmartStore.WebApp.MVC.Services;
using bruno.CatalogFilms.WebApp.MVC.Services.Interface;
using bruno.CatalogFilms.WebApp.MVC.Services;
using bruno.CatalogFilms.API.Core.User;
using bruno.CatalogFilms.WebApp.MVC.Services.Handlers;

namespace SmartStore.WebApp.MVC.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IAuthService, AuthService>();
            services.AddHttpClient<ICatalogFilmsService, CatalogFilmsService>()
                  .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();
        }
    }
}
