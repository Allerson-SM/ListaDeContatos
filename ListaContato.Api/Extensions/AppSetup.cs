using System;
using ListaContatos.Api.Services;
using ListaContatos.Data;
using ListaContatos.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace ListaContatos.Api.Extensions
{
    public static class AppSetup
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ServiceContato>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ContatoRepository>();

            return services;
        }

        public static IServiceCollection AddContext(this IServiceCollection services)
        {
            services.AddScoped<Contexto>();

            return services;
        }
    }
}
