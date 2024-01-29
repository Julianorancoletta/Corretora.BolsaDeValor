using Delivery.Core.Messages;
using FluentValidation;
using FluentValidation.Results;
using System;

namespace Corretora.BolsaDeValor.API.Application.Commands.Brand
{
    public class DeleteFavoritosCommand : Command
    {
        public DeleteFavoritosCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; protected set; }

        public override bool IsValid()
        {
            ValidationResult = new DeleteFavoritosCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class DeleteFavoritosCommandValidation : AbstractValidator<DeleteFavoritosCommand>
        {
            public DeleteFavoritosCommandValidation()
            {
                RuleFor(x => x.Id)
                    .NotNull()
                    .WithMessage("");
            }
        }
    }
}
