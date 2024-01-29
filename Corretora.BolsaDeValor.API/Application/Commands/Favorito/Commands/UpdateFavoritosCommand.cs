using Delivery.Core.Messages;
using FluentValidation;
using System;

namespace Corretora.BolsaDeValor.API.Application.Commands.Acoes
{
    public class UpdateFavoritosCommand : Command
    {
        public UpdateFavoritosCommand( Guid acoeseUUID, Guid usuarioUUID)
        {
            AcoeseUUID = acoeseUUID;
            UsuarioUUID = usuarioUUID;
        }

        public Guid ID { get;  set; }
        public Guid AcoeseUUID { get; init; }
        public Guid UsuarioUUID { get; init; }

        public override bool IsValid()
        {
            ValidationResult = new UpdateFavoritosCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class UpdateFavoritosCommandValidation : AbstractValidator<UpdateFavoritosCommand>
        {
            public UpdateFavoritosCommandValidation()
            {
                RuleFor(c => c.ID)
                     .NotEmpty()
                     .WithMessage("Invalid customer id");
            }
        }
    }
}
