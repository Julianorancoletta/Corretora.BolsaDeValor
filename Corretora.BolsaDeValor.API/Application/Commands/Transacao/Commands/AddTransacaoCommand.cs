using Delivery.Core.Messages;
using FluentValidation;
using System;

namespace Corretora.BolsaDeValor.API.Application.Commands.Acoes
{
    public class AddTransacaoCommand : Command
    {
        public AddTransacaoCommand(Guid acaoUUID, int tipo, decimal valor, int quantidade)
        {
            AcaoUUID = acaoUUID;
            Tipo = tipo;
            Valor = valor;
            Quantidade = quantidade;
        }

        public Guid AcaoUUID { get; init; }
        public int Tipo { get; init; }
        public decimal Valor { get; init; }
        public int Quantidade { get; init; }
        public override bool IsValid()
        {
            ValidationResult = new AddTransacaoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AddTransacaoValidation : AbstractValidator<AddTransacaoCommand>
        {
            public AddTransacaoValidation()
            {

            }
        }
    }
}
