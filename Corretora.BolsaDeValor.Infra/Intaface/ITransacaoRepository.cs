using Corretora.BolsaDeValor.Core.Domain;
using Corretora.BolsaDeValor.Core.DTO;
using Delivery.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corretora.BolsaDeValor.Infra.Intaface
{
    public interface ITransacaoRepository : IRepository<Transacao>
    {
        IUnitOfWork UnitOfWork { get; }

        Task<TransacaoDTO> Get();
    }
}
