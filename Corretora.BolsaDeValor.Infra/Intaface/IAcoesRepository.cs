using Delivery.Core.DomainObjects;
using Delivery.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Common;
using Corretora.BolsaDeValor.Core.Domain;

namespace Corretora.BolsaDeValor.Infra.Intaface
{
    public interface IAcoesRepository : IRepository<Acoes>
    {
        IUnitOfWork UnitOfWork { get; }
        Task<PagedResult<Acoes>> GetAll(int pageSize, int pageIndex, string query = null);
        Task<List<string>> GetAcoes(string query);
    }
}