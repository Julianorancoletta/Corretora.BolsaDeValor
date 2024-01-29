using System;
using Corretora.BolsaDeValor.API.Application.Commands.Acoes;
using Corretora.BolsaDeValor.Core.Domain;

namespace Corretora.BolsaDeValor.API.Application
{
    public static class ToFavoritoConvert
    {

        public static Favorito ConvertAcoes(this AddFavoritosCommand favorito) => new(
           favorito.AcoeseUUID,
           favorito.UsuarioUUID);



        public static Favorito ConvertAcoes(this UpdateFavoritosCommand favorito) => new(
          favorito.AcoeseUUID,
          favorito.UsuarioUUID){Id=favorito.ID };

    }
}
