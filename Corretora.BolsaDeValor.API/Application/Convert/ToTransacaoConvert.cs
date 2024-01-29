using Corretora.BolsaDeValor.API.Application.Commands.Acoes;
using Corretora.BolsaDeValor.Core.Domain;

namespace Corretora.BolsaDeValor.API.Application.Convert
{
    public static class ToTransacaoConvert
    {
        public static Transacao ConvertTrancao(this AddTransacaoCommand command) => new(
            command.AcaoUUID,
            command.Tipo,
            command.Valor,
            command.Quantidade);

        public static Transacao ConvertTrancao(this UpdateTransacaoCommand command) => new(
           command.AcaoUUID,
           command.Tipo,
           command.Valor,
           command.Quantidade)
        { Id = command.ID };


    }
}
