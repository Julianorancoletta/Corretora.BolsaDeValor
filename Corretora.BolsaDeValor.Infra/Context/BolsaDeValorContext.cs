using System;
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
            modelBuilder.Entity<Acoes>().HasData(
                new Acoes("MGLU3", "Magazine Luiza", 2.03M, 1.50M),
                new Acoes("B3SA3", "B3", 20.03M, 1.50M),
                new Acoes("ITUB4", "Itaú Unibanco", 32.03M, 1.50M)
            );
            modelBuilder.Entity<HistoricoAcoes>().HasData(
                new HistoricoAcoes(Convert.ToDateTime("2023-12-06"),"MGLU3", 2.03M, 1.50M, 2.03M, 1.50M, 1.50M,10000),
                new HistoricoAcoes(Convert.ToDateTime("2023-12-07"), "MGLU3", 2.03M, 1.50M, 2.03M, 1.50M, 1.50M, 10000),
                new HistoricoAcoes(Convert.ToDateTime("2023-12-08"), "MGLU3", 2.03M, 1.50M, 2.03M, 1.50M, 1.50M, 10000),
                new HistoricoAcoes(Convert.ToDateTime("2023-12-09"), "MGLU3", 2.03M, 1.50M, 2.03M, 1.50M, 1.50M, 10000)
            );
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        } 
    }
}