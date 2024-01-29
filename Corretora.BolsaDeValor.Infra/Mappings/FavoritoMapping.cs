using Corretora.BolsaDeValor.Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corretora.BolsaDeValor.Infra.Mappings
{
    public class FavoritoMapping : IEntityTypeConfiguration<Favorito>
    {
        public void Configure(EntityTypeBuilder<Favorito> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("id");

            builder.Property(c => c.AcoeseUUID)
                .HasColumnName("id_acao")
                .HasColumnType("uuid");

            builder.Property(c => c.UsuarioUUID)
                .HasColumnName("id_usuario")
                .HasColumnType("uuid");

            builder.ToTable("favorito");
        }
    }
}
