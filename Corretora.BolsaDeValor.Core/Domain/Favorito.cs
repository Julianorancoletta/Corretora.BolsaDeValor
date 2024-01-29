using Delivery.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Corretora.BolsaDeValor.Core.Domain
{
    public class Favorito : Entity, IAggregateRoot
    {
        public Favorito(Guid acoeseUUID, Guid usuarioUUID)
        {
            AcoeseUUID = acoeseUUID;
            UsuarioUUID = usuarioUUID;
        }

        public Guid AcoeseUUID { get; init; }
        public Guid UsuarioUUID { get; init; }

        public Acoes acoes { get; private set; }

    }
}
