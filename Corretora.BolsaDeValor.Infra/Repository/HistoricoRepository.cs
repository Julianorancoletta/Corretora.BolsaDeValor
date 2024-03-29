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

namespace Corretora.BolsaDeValor.Infra.Data.Repository
{
    public class HistoricoRepository(BolsaDeValorContext context) : BaseRepository<HistoricoAcoes>(context), IHistoricoRepository
    {
        private readonly BolsaDeValorContext _context = context;

        public IUnitOfWork UnitOfWork => _context;

        public async Task<PagedResult<HistoricoAcoes>> GetAll(int pageSize, int pageIndex, string symbol)
        {
            var catalogQuery = _context.Historico.AsQueryable();

            var catalog = await catalogQuery.AsNoTrackingWithIdentityResolution()
                                            .Where(x => x.Symbol == symbol)
                                            .Skip(pageSize * (pageIndex - 1))
                                            .Take(pageSize).ToListAsync();

            var total = await catalogQuery.AsNoTrackingWithIdentityResolution()
                                            .Where(x => x.Symbol == symbol)
                                          .CountAsync();


            return new PagedResult<HistoricoAcoes>()
            {
                List = catalog,
                TotalResults = total,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = symbol.ToString()
            };
        }
    }


}