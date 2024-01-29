using Corretora.BolsaDeValor.Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Corretora.BolsaDeValor.Infra.Mappings
{
    internal class TransacaoMapping : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("id");

            builder.Property(c => c.AcaoUUID)
               .HasColumnName("id_acoes")
               .HasColumnType("uuid");

            builder.Property(c => c.Tipo)
                .HasColumnName("tipo")
                .HasColumnType("int");

            builder.Property(c => c.Valor)
                .HasColumnName("valor")
                .HasColumnType("decimal(10,2)");

            builder.Property(c => c.Quantidade)
                .HasConversion<int>()
                .HasColumnName("quantidade")
                .HasColumnType("int");


            builder.ToTable("transacao");
        }
    }
}  