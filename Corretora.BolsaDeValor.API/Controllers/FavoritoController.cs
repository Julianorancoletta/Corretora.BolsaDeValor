using Corretora.BolsaDeValor.API.Application.Commands.Acoes;
using Corretora.BolsaDeValor.API.Application.Commands.Brand;
using Corretora.BolsaDeValor.Core.Domain;
using Corretora.BolsaDeValor.Infra.Data.Repository;
using Corretora.BolsaDeValor.Infra.Intaface;
using Delivery.Core.DomainObjects;
using Delivery.Core.Mediator;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Delivery.WebAPI.Core.Controllers;

namespace Corretora.BolsaDeValor.API.Controllers
{
    [Route("api/[Controller]")]
    public class FavoritoController : MainController
    {
        private readonly IMediatorHandler _mediator;
        private readonly IFavoritosRepository _favoritosRepository;

        public FavoritoController(IMediatorHandler mediator, IFavoritosRepository favoritosRepository)
        {
            _mediator = mediator;
            _favoritosRepository = favoritosRepository;
        }

        [HttpGet("{usuario}")]
        public async Task<PagedResult<Favorito>> get(Guid usuario ,[FromQuery] int ps = 8, [FromQuery] int page = 1) => await _favoritosRepository.GetAll(ps, page, usuario);


        [HttpPost]
        public async Task<IActionResult> add(AddFavoritosCommand Acoes)
        {
            return CustomResponse(await _mediator.SendCommand(Acoes));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateFavoritosCommand Acoes)
        {
            return CustomResponse(await _mediator.SendCommand(Acoes));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse(await _mediator.SendCommand(new DeleteFavoritosCommand(id)));
        }

    }
}
