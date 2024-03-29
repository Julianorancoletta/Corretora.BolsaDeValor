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
    public class FavoritosRepository(BolsaDeValorContext context) : BaseRepository<Favorito>(context), IFavoritosRepository
    {
        private readonly BolsaDeValorContext _context = context;

        public IUnitOfWork UnitOfWork => _context;


        public async Task<PagedResult<Favorito>> GetAll(int pageSize, int pageIndex,Guid usuario)
        {
            var catalogQuery = _context.Favorito.AsQueryable();

            var catalog = await catalogQuery.AsNoTrackingWithIdentityResolution()
                                            .Include(x=> x.acoes)
                                            .Where(x => x.UsuarioUUID == usuario)
                                            .Skip(pageSize * (pageIndex - 1))
                                            .Take(pageSize).ToListAsync();

            var total = await catalogQuery.AsNoTrackingWithIdentityResolution()
                                            .Where(x => x.UsuarioUUID == usuario)
                                          .CountAsync();


            return new PagedResult<Favorito>()
            {
                List = catalog,
                TotalResults = total,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Query = usuario.ToString()
            };
        }
    }


}