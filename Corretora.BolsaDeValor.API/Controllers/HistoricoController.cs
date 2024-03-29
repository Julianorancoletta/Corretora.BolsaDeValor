using Delivery.Core.DomainObjects;
using Delivery.Core.Mediator;
using Delivery.WebAPI.Core.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Corretora.BolsaDeValor.Core.Domain;
using Corretora.BolsaDeValor.Infra.Intaface;

namespace Corretora.BolsaDeValor.API.Controllers
{
    [Route("api/[Controller]")]
    public class HistoricoController : MainController
    {
        private readonly IMediatorHandler _mediator;
        private readonly IHistoricoRepository _HistoricoRepository;

        public HistoricoController(IMediatorHandler mediator, IHistoricoRepository HistoricoRepository)
        {
            _mediator = mediator;
            _HistoricoRepository = HistoricoRepository;
        }


        [HttpGet("{codigo}")]
        public async Task<PagedResult<HistoricoAcoes>> Index(string codigo,[FromQuery] int ps = 8, [FromQuery] int page = 1)
        {
            return await _HistoricoRepository.GetAll(ps, page, codigo);
        }


        [HttpGet("Dia/{id}")]
        public async Task<HistoricoAcoes> Details(Guid id)
        {
            return await _HistoricoRepository.GetById(id);
        }
    }
}