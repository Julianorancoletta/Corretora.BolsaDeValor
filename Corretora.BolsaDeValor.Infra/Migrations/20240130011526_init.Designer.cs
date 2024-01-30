﻿// <auto-generated />
using System;
using Corretora.BolsaDeValor.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Corretora.BolsaDeValor.Infra.Migrations
{
    [DbContext(typeof(BolsaDeValorContext))]
    [Migration("20240130011526_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Corretora.BolsaDeValor.Core.Domain.Acoes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Codigo")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("codigo");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.Property<decimal>("Ultima")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("ultima");

                    b.Property<decimal>("Variacao")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("variacao");

                    b.HasKey("Id");

                    b.ToTable("acao", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("15e69908-9535-4710-bb75-37770fa16c03"),
                            Codigo = "MGLU3",
                            Nome = "Magazine Luiza",
                            Ultima = 2.03m,
                            Variacao = 1.50m
                        },
                        new
                        {
                            Id = new Guid("a4acac06-ebb3-4112-80dd-60c5774d63c4"),
                            Codigo = "B3SA3",
                            Nome = "B3",
                            Ultima = 20.03m,
                            Variacao = 1.50m
                        },
                        new
                        {
                            Id = new Guid("69e00748-4b83-458f-9f72-d63befa1a59e"),
                            Codigo = "ITUB4",
                            Nome = "Itaú Unibanco",
                            Ultima = 32.03m,
                            Variacao = 1.50m
                        });
                });

            modelBuilder.Entity("Corretora.BolsaDeValor.Core.Domain.Favorito", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AcoeseUUID")
                        .HasColumnType("uuid")
                        .HasColumnName("id_acao");

                    b.Property<Guid>("UsuarioUUID")
                        .HasColumnType("uuid")
                        .HasColumnName("id_usuario");

                    b.HasKey("Id");

                    b.HasIndex("AcoeseUUID");

                    b.ToTable("favorito", (string)null);
                });

            modelBuilder.Entity("Corretora.BolsaDeValor.Core.Domain.HistoricoAcoes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("Data")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("FechamentoValor")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("fechamento_valor");

                    b.Property<decimal>("Fechamneto")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("fechamento");

                    b.Property<decimal>("MaximorValor")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("maximor_valor");

                    b.Property<decimal>("MenorvValor")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("menor_valor");

                    b.Property<string>("Symbol")
                        .HasColumnType("varchar(10)")
                        .HasColumnName("symbol");

                    b.Property<decimal>("ValorAbertura")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("valor_abertura");

                    b.Property<int>("Volume")
                        .HasColumnType("int")
                        .HasColumnName("volume");

                    b.HasKey("Id");

                    b.ToTable("historico_acao", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("24f8ec1d-ea10-4066-ad9d-255eaa4dfdb8"),
                            Data = new DateTime(2023, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechamentoValor = 1.50m,
                            Fechamneto = 1.50m,
                            MaximorValor = 1.50m,
                            MenorvValor = 2.03m,
                            Symbol = "MGLU3",
                            ValorAbertura = 2.03m,
                            Volume = 10000
                        },
                        new
                        {
                            Id = new Guid("a9aa8440-85c2-403c-b991-1a775c05bfd0"),
                            Data = new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechamentoValor = 1.50m,
                            Fechamneto = 1.50m,
                            MaximorValor = 1.50m,
                            MenorvValor = 2.03m,
                            Symbol = "MGLU3",
                            ValorAbertura = 2.03m,
                            Volume = 10000
                        },
                        new
                        {
                            Id = new Guid("4cd91a35-fccb-4f40-8d31-e4f5128eb487"),
                            Data = new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechamentoValor = 1.50m,
                            Fechamneto = 1.50m,
                            MaximorValor = 1.50m,
                            MenorvValor = 2.03m,
                            Symbol = "MGLU3",
                            ValorAbertura = 2.03m,
                            Volume = 10000
                        },
                        new
                        {
                            Id = new Guid("f3854899-fb57-4427-b4c3-713605f68b76"),
                            Data = new DateTime(2023, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FechamentoValor = 1.50m,
                            Fechamneto = 1.50m,
                            MaximorValor = 1.50m,
                            MenorvValor = 2.03m,
                            Symbol = "MGLU3",
                            ValorAbertura = 2.03m,
                            Volume = 10000
                        });
                });

            modelBuilder.Entity("Corretora.BolsaDeValor.Core.Domain.Transacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AcaoUUID")
                        .HasColumnType("uuid")
                        .HasColumnName("id_acoes");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("quantidade");

                    b.Property<int>("Tipo")
                        .HasColumnType("int")
                        .HasColumnName("tipo");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("valor");

                    b.HasKey("Id");

                    b.HasIndex("AcaoUUID");

                    b.ToTable("transacao", (string)null);
                });

            modelBuilder.Entity("Corretora.BolsaDeValor.Core.Domain.Favorito", b =>
                {
                    b.HasOne("Corretora.BolsaDeValor.Core.Domain.Acoes", "acoes")
                        .WithMany("favorito")
                        .HasForeignKey("AcoeseUUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("acoes");
                });

            modelBuilder.Entity("Corretora.BolsaDeValor.Core.Domain.Transacao", b =>
                {
                    b.HasOne("Corretora.BolsaDeValor.Core.Domain.Acoes", "acoes")
                        .WithMany("transacaos")
                        .HasForeignKey("AcaoUUID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("acoes");
                });

            modelBuilder.Entity("Corretora.BolsaDeValor.Core.Domain.Acoes", b =>
                {
                    b.Navigation("favorito");

                    b.Navigation("transacaos");
                });
#pragma warning restore 612, 618
        }
    }
}