
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Corretora.BolsaDeValor.Infra.Context;
using System.Diagnostics.CodeAnalysis;

namespace Corretora.BolsaDeValor.API.Configuration
{
    [ExcludeFromCodeCoverage]
    public static class DbMigrationHelpers
    {
        public static async Task EnsureSeedData(WebApplication serviceScope)
        {
            var services = serviceScope.Services.CreateScope().ServiceProvider;
            await EnsureSeedData(services);
        }

        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

            var context = scope.ServiceProvider.GetRequiredService<BolsaDeValorContext>();

            if (env.IsDevelopment() || env.IsEnvironment("Docker"))
            {
                await context.Database.EnsureCreatedAsync();
            }
        }
    }

}
