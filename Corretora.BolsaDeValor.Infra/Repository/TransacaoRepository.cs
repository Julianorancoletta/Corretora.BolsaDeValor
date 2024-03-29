using Delivery.Core.DomainObjects;
using Delivery.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corretora.BolsaDeValor.Infra.Context;
using System.Data.Common;
using Corretora.BolsaDeValor.Core.Domain;
using Corretora.BolsaDeValor.Infra.Intaface;
using Dapper;
using Corretora.BolsaDeValor.Core.DTO;

namespace Corretora.BolsaDeValor.Infra.Data.Repository
{
    public class TransacaoRepository(BolsaDeValorContext context) : BaseRepository<Transacao>(context), ITransacaoRepository
    {
        private readonly BolsaDeValorContext _context = context;
        public IUnitOfWork UnitOfWork => _context;

        public DbConnection GetConnection() => _context.Database.GetDbConnection();
        public async Task<TransacaoDTO> Get()
        {
            List<BalaceDTO> Balace = new();

            var sql = @"select  
                            t.id
                            ,t.id_acoes as acaoID
                            ,t.tipo
                            ,t.valor
                            ,t.quantidade
                            ,a.nome
                            ,a.codigo
                            from transacao t 
                            inner join acao a on a.id = t.id_acoes";

            var transacao = await GetConnection().QueryAsync<TransacaoItemDTO>(sql);

            foreach (var item in transacao.GroupBy(x => x.acaoID).ToList())
            {
                var compra = item.Where(x => x.Tipo == 1).Sum(x => x.Valor * x.Quantidade);
                var Venda = item.Where(x => x.Tipo == 2).Sum(x => x.Valor * x.Quantidade);
                var Quantidadecompra = item.Where(x => x.Tipo == 1).Select(x => x.Quantidade).Sum();
                var QuantidadeVenda = item.Where(x => x.Tipo == 2).Select(x => x.Quantidade).Sum();

                Balace.Add(new(
                    (compra - Venda),
                    (Quantidadecompra - QuantidadeVenda),
                    item.Select(x => x.Nome).FirstOrDefault(),
                    item.Select(x => x.codigo).FirstOrDefault()));
            }

            return new TransacaoDTO(transacao.ToList(),Balace);

        }
    }
}