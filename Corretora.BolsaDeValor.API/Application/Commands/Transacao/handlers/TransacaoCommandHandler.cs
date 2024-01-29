using Delivery.Core.Messages;
using FluentValidation.Results;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Corretora.BolsaDeValor.Infra.Intaface;
using Corretora.BolsaDeValor.API.Application.Convert;


namespace Corretora.BolsaDeValor.API.Application.Commands.Acoes
{
    public class TransacaoCommandHandler : CommandHandler,
        IRequestHandler<AddTransacaoCommand, ValidationResult>,
        IRequestHandler<UpdateTransacaoCommand, ValidationResult>
    {

        private readonly ITransacaoRepository _transacao;

        public TransacaoCommandHandler(ITransacaoRepository transacaoRepository)
        {
            _transacao = transacaoRepository;
        }

        public async Task<ValidationResult> Handle(AddTransacaoCommand message, CancellationToken cancellationToken)
        {

            if (!message.IsValid()) return message.ValidationResult;

            await _transacao.Add(message.ConvertTrancao());

            return await PersistData(_transacao.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateTransacaoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            _transacao.Update(message.ConvertTrancao());

            return await PersistData(_transacao.UnitOfWork);
        }


    }
}
