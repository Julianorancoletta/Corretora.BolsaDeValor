using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Corretora.BolsaDeValor.API.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            // API
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            NativeInjectorBootStrapper.RegisterServices(services);
        }

    }
}
