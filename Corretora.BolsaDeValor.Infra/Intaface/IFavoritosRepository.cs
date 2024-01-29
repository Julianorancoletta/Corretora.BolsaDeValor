using Corretora.BolsaDeValor.Core.Domain;
using Delivery.Core.Data;
using Delivery.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corretora.BolsaDeValor.Infra.Intaface
{
    public interface IFavoritosRepository : IRepository<Favorito>
    {

        IUnitOfWork UnitOfWork { get; }

        public Task<PagedResult<Favorito>> GetAll(int pageSize, int pageIndex, Guid usuario);
    }
}
