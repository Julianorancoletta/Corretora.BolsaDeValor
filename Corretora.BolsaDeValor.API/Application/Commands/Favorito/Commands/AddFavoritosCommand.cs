using Delivery.Core.Messages;
using FluentValidation;
using System;

namespace Corretora.BolsaDeValor.API.Application.Commands.Acoes
{
    public class AddFavoritosCommand : Command
    {
        public AddFavoritosCommand(Guid AcoeseUUID, Guid usuarioUUID)
        {
            this.AcoeseUUID = AcoeseUUID;
            UsuarioUUID = usuarioUUID;
        }

        public Guid AcoeseUUID { get; init; }
        public Guid UsuarioUUID { get; init; }

        public override bool IsValid()
        {
            ValidationResult = new AddFavoritosValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AddFavoritosValidation : AbstractValidator<AddFavoritosCommand>
        {
            public AddFavoritosValidation()
            {
                RuleFor(c => c.AcoeseUUID)
                     .NotEmpty()
                     .WithMessage("mandatory name");

                RuleFor(c => c.UsuarioUUID)
                     .NotEmpty()
                     .WithMessage("mandatory description");
            }
        }
    }
}
