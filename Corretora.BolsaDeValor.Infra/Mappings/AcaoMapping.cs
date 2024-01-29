using Corretora.BolsaDeValor.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Corretora.BolsaDeValor.infra.Data.Mappings
{
    public class AcoesMapping : IEntityTypeConfiguration<Acoes>
    {
        public void Configure(EntityTypeBuilder<Acoes> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("id");

            builder.Property(c => c.Codigo)
                .HasColumnName("codigo")
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Nome)
                .HasColumnName("nome")
                .HasColumnType("varchar(100)");

            builder.Property(c => c.Ultima)
                .HasColumnName("ultima")
                .HasColumnType("decimal(10,2)");

            builder.Property(c => c.Variacao)
                .HasColumnName("variacao")
                .HasColumnType("decimal(10,2)");

           builder.HasMany(p => p.favorito)
                   .WithOne(r => r.acoes)
                    .HasForeignKey(r => r.AcoeseUUID);

            builder.HasMany(p => p.transacaos)
                  .WithOne(r => r.acoes)
                   .HasForeignKey(r => r.AcaoUUID);

            builder.ToTable("acao");
        }
    }
}
