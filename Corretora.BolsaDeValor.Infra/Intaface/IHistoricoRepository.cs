using Corretora.BolsaDeValor.Core.Domain;
using Delivery.Core.Data;
using Delivery.Core.DomainObjects;
using System.Threading.Tasks;

namespace Corretora.BolsaDeValor.Infra.Intaface
{
    public interface IHistoricoRepository : IRepository<HistoricoAcoes>
    {
        IUnitOfWork UnitOfWork { get; }
        Task<PagedResult<HistoricoAcoes>> GetAll(int pageSize, int pageIndex, string symbol);
    }
}
