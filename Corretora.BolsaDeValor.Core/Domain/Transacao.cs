using Delivery.Core.DomainObjects;
using System;

namespace Corretora.BolsaDeValor.Core.Domain
{
    public class Transacao : Entity, IAggregateRoot
    {
        public Transacao(Guid acaoUUID, int tipo, decimal valor, int quantidade)
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

        public Acoes acoes { get; private set; }
    }
}
