using Delivery.Core.Messages;
using FluentValidation;
using System;

namespace Corretora.BolsaDeValor.API.Application.Commands.Acoes
{
    public class UpdateTransacaoCommand : Command
    {
        public UpdateTransacaoCommand(Guid iD, Guid acaoUUID, int tipo, decimal valor, int quantidade)
        {
            ID = iD;
            AcaoUUID = acaoUUID;
            Tipo = tipo;
            Valor = valor;
            Quantidade = quantidade;
        }

        public Guid ID { get; init; }
        public Guid AcaoUUID { get; init; }
        public int Tipo { get; init; }
        public decimal Valor { get; init; }
        public int Quantidade { get; init; }

        public override bool IsValid()
        {
            ValidationResult = new UpdateTransacaoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class UpdateTransacaoCommandValidation : AbstractValidator<UpdateTransacaoCommand>
        {
            public UpdateTransacaoCommandValidation()
            {
                RuleFor(c => c.ID)
                     .NotEmpty()
                     .WithMessage("Invalid customer id");
            }
        }
    }
}
