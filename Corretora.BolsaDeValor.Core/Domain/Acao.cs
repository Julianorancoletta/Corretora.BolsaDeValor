using Delivery.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Corretora.BolsaDeValor.Core.Domain
{
    public class Acoes : Entity, IAggregateRoot
    {
        public Acoes(string codigo, string nome, decimal ultima, decimal variacao)
        {
            Codigo = codigo;
            Nome = nome;
            Ultima = ultima;
            Variacao = variacao;
        }

        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public decimal Ultima { get; private set; }
        public decimal Variacao { get; private set; }


        [JsonIgnore]
        public IReadOnlyCollection<Favorito> favorito { get; set; }
        [JsonIgnore]
        public IReadOnlyCollection<Transacao> transacaos { get; set; }
    }
}
