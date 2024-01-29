using Delivery.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Corretora.BolsaDeValor.Core.Domain
{
    public class HistoricoAcoes : Entity, IAggregateRoot
    {
        public HistoricoAcoes(DateTime data, string symbol, decimal valorAbertura, decimal maximorValor, decimal menorvValor, decimal fechamentoValor, decimal fechamneto, int volume)
        {
            Data = data;
            Symbol = symbol;
            ValorAbertura = valorAbertura;
            MaximorValor = maximorValor;
            MenorvValor = menorvValor;
            FechamentoValor = fechamentoValor;
            Fechamneto = fechamneto;
            Volume = volume;
        }

        public DateTime Data { get; init; }
        public string Symbol { get; init; }
        public decimal ValorAbertura { get; init; }
        public decimal MaximorValor { get; init; }
        public decimal MenorvValor { get; init; }
        public decimal FechamentoValor { get; init; }
        public decimal Fechamneto { get; init; }
        public int Volume { get; init; }

    }
}
