using Delivery.Core.Messages;
using FluentValidation.Results;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Corretora.BolsaDeValor.Infra.Intaface;


namespace Corretora.BolsaDeValor.API.Application.Commands.Acoes
{
    public class FavoritosCommandHandler : CommandHandler,
        IRequestHandler<AddFavoritosCommand, ValidationResult>,
        IRequestHandler<UpdateFavoritosCommand, ValidationResult>
    {

        private readonly IFavoritosRepository _favoritos;

        public FavoritosCommandHandler(IFavoritosRepository favoritosRepository) => _favoritos = favoritosRepository;

        public async Task<ValidationResult> Handle(AddFavoritosCommand message, CancellationToken cancellationToken)
        {

            if (!message.IsValid()) return message.ValidationResult;

            await _favoritos.Add(message.ConvertAcoes());

            return await PersistData(_favoritos.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateFavoritosCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            _favoritos.Update(message.ConvertAcoes());

            return await PersistData(_favoritos.UnitOfWork);
        }


    }
}
