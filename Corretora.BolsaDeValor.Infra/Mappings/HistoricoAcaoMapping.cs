using Corretora.BolsaDeValor.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Corretora.BolsaDeValor.infra.Data.Mappings
{
    public class HistoricoAcoesMapping : IEntityTypeConfiguration<HistoricoAcoes>
    {
        public void Configure(EntityTypeBuilder<HistoricoAcoes> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("id");

            builder.Property(c => c.Symbol)
                .HasColumnName("symbol")
                .HasColumnType("varchar(10)");

            builder.Property(c => c.ValorAbertura)
                .HasColumnName("valor_abertura")
                .HasColumnType("decimal(10,2)");

            builder.Property(c => c.MaximorValor)
                .HasColumnName("maximor_valor")
                .HasColumnType("decimal(10,2)");

            builder.Property(c => c.MenorvValor)
                .HasColumnName("menor_valor")
                .HasColumnType("decimal(10,2)");

            builder.Property(c => c.FechamentoValor)
                .HasColumnName("fechamento_valor")
                .HasColumnType("decimal(10,2)");

            builder.Property(c => c.Fechamneto)
                .HasColumnName("fechamento")
                .HasColumnType("decimal(10,2)");

            builder.Property(c => c.Volume)
                .HasColumnName("volume")
                .HasColumnType("int");

            builder.ToTable("historico_acao");
        }
    }
}
