using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corretora.BolsaDeValor.Core.DTO
{
    public record TransacaoDTO(List<TransacaoItemDTO> ItemDTOs,List<BalaceDTO> Balace);

    public record TransacaoItemDTO(Guid id, Guid acaoID, int Tipo, Decimal Valor, int Quantidade, string Nome, string codigo);

    public record BalaceDTO(Decimal Valor, int Quantidade, string Nome, string codigo);
}
