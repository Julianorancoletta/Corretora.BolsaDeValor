using Delivery.Core.DomainObjects;
using Delivery.Core.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corretora.BolsaDeValor.Infra.Context;
using Corretora.BolsaDeValor.Core.Domain;
using Corretora.BolsaDeValor.Infra.Intaface;

namespace Corretora.BolsaDeValor.Infra.Data.Repository
{
    public class AcoesRepository(BolsaDeValorContext context) : BaseRepository<Acoes>(context), IAcoesRepository
    {
        private readonly BolsaDeValorContext _context = context;

        public IUnitOfWork UnitOfWork => _context;
        public async Task<PagedResult<Acoes>> GetAll(int pageSize, int pageIndex, string query = null)
        {
            var catalogQuery = _context.Acoes.AsQueryable();

            var catalog = await catalogQuery.AsNoTrackingWithIdentityResolution()
                                            .Where(x => EF.Functions.Like(x.Codigo, $"%{query}%"))
                                            .OrderBy(x => x.Codigo)
                                            .Skip(pageSize * (pageIndex - 1))
                                            .Take(pageSize).ToListAsync();

            var total = await catalogQuery.AsNoTrackingWithIdentityResolution()
                                          .Where(x => EF.Functions.Like(x.Codigo, $"%{query}%"))
                                          .CountAsync();


            return new PagedResult<Acoes>()
            {
                List = catalog,
                TotalResults = total,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = query
            };
        }


        public async Task<List<string>> GetAcoes(string query)
        {
            var catalogQuery = _context.Acoes.AsQueryable();

            return await catalogQuery.AsNoTrackingWithIdentityResolution()
                                            .Select(x => x.Codigo)
                                            .Where(x => EF.Functions.Like(x, $"%{query}%")).Distinct().ToListAsync();
        }

    }
}