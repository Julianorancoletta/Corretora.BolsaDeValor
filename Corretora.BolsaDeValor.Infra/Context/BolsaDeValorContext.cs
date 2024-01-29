using System.Linq;
using System.Threading.Tasks;
using Corretora.BolsaDeValor.Core.Domain;
using Delivery.Core.Data;
using Delivery.Core.Messages;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace Corretora.BolsaDeValor.Infra.Context
{
    public class BolsaDeValorContext : DbContext, IUnitOfWork
    {
        public BolsaDeValorContext(DbContextOptions<BolsaDeValorContext> options): base(options) { }

        public DbSet<Acoes> Acoes { get; set; }
        public DbSet<Favorito> Favorito { get; set; }
        public DbSet<HistoricoAcoes> Historico { get; set; }
        public DbSet<Transacao> Transacao { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BolsaDeValorContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        } 
    }
}