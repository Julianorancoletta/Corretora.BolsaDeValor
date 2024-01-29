using Corretora.BolsaDeValor.Infra.Context;
using Corretora.BolsaDeValor.Infra.Data.Repository;
using Corretora.BolsaDeValor.Infra.Intaface;
using Delivery.Core.Mediator;
using Microsoft.Extensions.DependencyInjection;


public static class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services)
    {
        // Application
        services.AddScoped<IMediatorHandler, MediatorHandler>();
        services.AddScoped<IAcoesRepository, AcoesRepository>()
            .AddScoped<IFavoritosRepository, FavoritosRepository>()
            .AddScoped<IHistoricoRepository, HistoricoRepository>()
            .AddScoped<ITransacaoRepository, TransacaoRepository>()
            .AddScoped<BolsaDeValorContext>();
    }
}
