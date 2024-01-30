using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Corretora.BolsaDeValor.Infra.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "acao",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    codigo = table.Column<string>(type: "varchar(100)", nullable: true),
                    nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    ultima = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    variacao = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_acao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "historico_acao",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Data = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    symbol = table.Column<string>(type: "varchar(10)", nullable: true),
                    valor_abertura = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    maximor_valor = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    menor_valor = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    fechamento_valor = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    fechamento = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    volume = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historico_acao", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "favorito",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    id_acao = table.Column<Guid>(type: "uuid", nullable: false),
                    id_usuario = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_favorito", x => x.id);
                    table.ForeignKey(
                        name: "FK_favorito_acao_id_acao",
                        column: x => x.id_acao,
                        principalTable: "acao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transacao",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    id_acoes = table.Column<Guid>(type: "uuid", nullable: false),
                    tipo = table.Column<int>(type: "int", nullable: false),
                    valor = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transacao", x => x.id);
                    table.ForeignKey(
                        name: "FK_transacao_acao_id_acoes",
                        column: x => x.id_acoes,
                        principalTable: "acao",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "acao",
                columns: new[] { "id", "codigo", "nome", "ultima", "variacao" },
                values: new object[,]
                {
                    { new Guid("15e69908-9535-4710-bb75-37770fa16c03"), "MGLU3", "Magazine Luiza", 2.03m, 1.50m },
                    { new Guid("69e00748-4b83-458f-9f72-d63befa1a59e"), "ITUB4", "Itaú Unibanco", 32.03m, 1.50m },
                    { new Guid("a4acac06-ebb3-4112-80dd-60c5774d63c4"), "B3SA3", "B3", 20.03m, 1.50m }
                });

            migrationBuilder.InsertData(
                table: "historico_acao",
                columns: new[] { "id", "Data", "fechamento_valor", "fechamento", "maximor_valor", "menor_valor", "symbol", "valor_abertura", "volume" },
                values: new object[,]
                {
                    { new Guid("24f8ec1d-ea10-4066-ad9d-255eaa4dfdb8"), new DateTime(2023, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.50m, 1.50m, 1.50m, 2.03m, "MGLU3", 2.03m, 10000 },
                    { new Guid("4cd91a35-fccb-4f40-8d31-e4f5128eb487"), new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.50m, 1.50m, 1.50m, 2.03m, "MGLU3", 2.03m, 10000 },
                    { new Guid("a9aa8440-85c2-403c-b991-1a775c05bfd0"), new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.50m, 1.50m, 1.50m, 2.03m, "MGLU3", 2.03m, 10000 },
                    { new Guid("f3854899-fb57-4427-b4c3-713605f68b76"), new DateTime(2023, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.50m, 1.50m, 1.50m, 2.03m, "MGLU3", 2.03m, 10000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_favorito_id_acao",
                table: "favorito",
                column: "id_acao");

            migrationBuilder.CreateIndex(
                name: "IX_transacao_id_acoes",
                table: "transacao",
                column: "id_acoes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "favorito");

            migrationBuilder.DropTable(
                name: "historico_acao");

            migrationBuilder.DropTable(
                name: "transacao");

            migrationBuilder.DropTable(
                name: "acao");
        }
    }
}
